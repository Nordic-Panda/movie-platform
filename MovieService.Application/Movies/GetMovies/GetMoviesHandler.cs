using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Application.Common.Settings;
using MovieService.Application.Movies.GetMovies.Filters;

namespace MovieService.Application.Movies.GetMovies
{
    public class GetMoviesHandler : IRequestHandler<GetMoviesQuery, PagedResult<MovieDto>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMovieActorRepository _movieActorRepository;
        private readonly IActorRepository _actorRepository;
        private readonly PaginationSettings _settings;

        public GetMoviesHandler(
            IMovieRepository movieRepository,
            IMovieActorRepository movieActorRepository,
            IActorRepository actorRepository,
            IOptions<PaginationSettings> settings
        )
        {
            _movieRepository = movieRepository;
            _movieActorRepository = movieActorRepository;
            _actorRepository = actorRepository;
            _settings = settings.Value;
        }

        public async Task<PagedResult<MovieDto>> Handle(
            GetMoviesQuery request,
            CancellationToken cancellationToken
        )
        {
            var page = request.Page ?? _settings.DefaultPage;
            var pageSize = request.PageSize ?? _settings.DefaultPageSize;

            var movies = _movieRepository.Query();
            var movieActors = _movieActorRepository.Query();
            var actors = _actorRepository.Query();

            // These are still just IQueryable / Expression tree

            // Include Genres because filtering by movie.Genres does not load the related entities.
            // ApplyGenreFilter only affects which movies are returned.
            var query = movies
                .Where(m => m.IsActive)
                .Include(m => m.Genres)
                .Include(m => m.Language)
                .Include(m => m.Details)
                    .ThenInclude(d => d.Budget)
                        .ThenInclude(d => d.Currency)
                .ApplyGenreFilter(request.GenreIds)
                .ApplyTitleFilter(request.Title)
                .ApplyDurationFilter(request.Duration)
                .ApplyActorFilter(
                    request.ActorFirstName,
                    request.ActorLastName,
                    movieActors,
                    actors
                );

            // Count pages before skip and take
            var totalCount = await query.CountAsync(cancellationToken);

            // Avoid nullable in DTO mapping
            // Send cancellation token to ToListAsync so when user close browser or navigates away
            // We wouldn't waste resources, reduce load under heavy traffic
            var result = await query
                .OrderBy(m => m.Title)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var items = result.Select(m => MovieMapper.ToDto(m)).ToList();

            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            return new PagedResult<MovieDto>(items, page, pageSize, totalCount, totalPages);

            // We cannot use MovieMapper.ToDto inside the EF Core IQueryable projection
            // because EF Core may not be able to translate custom C# methods into SQL.
            // So ABOVE we first execute the query and get the Movie entities from the database,
            // then map them to DTOs in memory.

            //var result = await query
            //    .OrderBy(m => m.Title)
            //    .Skip((page - 1) * pageSize)
            //    .Take(pageSize)
            //    .Select(m => new MovieDto
            //    (
            //        m.Id,
            //        m.Title,
            //        (int)m.Duration.TotalMinutes,
            //        m.Genres.Select(GenreMapper.ToDto).ToList(),
            //        m.Details.Language,
            //        m.Details.Synopsis,
            //        m.Details.Budget != null ? m.Details.Budget.Amount : null,
            //        m.Details.Budget != null ? m.Details.Budget.Currency : null
            //    ))
            //    .ToListAsync(cancellationToken);

            //return result;
        }
    }
}
