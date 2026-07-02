using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Settings;
using MovieService.Application.Movies.GetMovies.Filters;

namespace MovieService.Application.Movies.GetMovies
{
    public class GetMoviesHandler : IRequestHandler<GetMoviesQuery, IReadOnlyList<MovieDto>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMovieActorRepository _movieActorRepository;
        private readonly IActorRepository _actorRepository;
        private readonly PaginationSettings _settings;

        public GetMoviesHandler(IMovieRepository movieRepository, IMovieActorRepository movieActorRepository, IActorRepository actorRepository, IOptions<PaginationSettings> settings)
        {
            _movieRepository = movieRepository;
            _movieActorRepository = movieActorRepository;
            _actorRepository = actorRepository;
            _settings = settings.Value;
        }
        public async Task<IReadOnlyList<MovieDto>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            var page = request.Page ?? _settings.DefaultPage;
            var pageSize = _settings.DefaultPageSize;
            
            var movies = _movieRepository.Query();
            var movieActors = _movieActorRepository.Query();
            var actors = _actorRepository.Query();

            // These are still just IQueryable / Expression tree
            var query = movies
                .ApplyGenreFilter(request.Genre)
                .ApplyTitleFilter(request.Title)
                .ApplyDurationFilter(request.Duration)
                .ApplyActorFilter(
                    request.ActorFirstName,
                    request.ActorLastName,
                    movieActors,
                    actors);

            // Avoid nullable in DTO mapping
            // Send cancellation token to ToListAsync so when user close browser or navigates away
            // We wouldn't waste resources, reduce load under heavy traffic
            var result = await query
                .OrderBy(m => m.Title)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(m => new MovieDto
                (
                    m.Id,
                    m.Title,
                    (int)m.Duration.TotalMinutes,
                    m.Genre.ToString(),
                    m.Details.Language,
                    m.Details.Synopsis,
                    m.Details.Budget != null ? m.Details.Budget.Amount : null,
                    m.Details.Budget != null ? m.Details.Budget.Currency : null
                ))
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
