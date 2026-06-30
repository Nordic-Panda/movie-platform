using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Currency;
using MovieService.Domain.Enums;

namespace MovieService.Application.Movies.GetMovies
{
    public class GetMoviesHandler : IRequestHandler<GetMoviesQuery, IReadOnlyList<MovieDto>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMovieActorRepository _movieActorRepository;
        private readonly IActorRepository _actorRepository;

        public GetMoviesHandler(IMovieRepository movieRepository, IMovieActorRepository movieActorRepository, IActorRepository actorRepository)
        {
            _movieRepository = movieRepository;
            _movieActorRepository = movieActorRepository;
            _actorRepository = actorRepository;
        }
        public async Task<IReadOnlyList<MovieDto>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = _movieRepository.Query();
            var movieActorQuery= _movieActorRepository.Query();
            var actorQuery = _actorRepository.Query();

            // Genre, param true ignores Case
            if (!string.IsNullOrWhiteSpace(request.Genre))
            {
                if (Enum.TryParse<Genre>(request.Genre, true, out var genre))
                {
                    movies = movies.Where(m => m.Genre == genre);
                }
            }

            // Title
            // In C# Contains is case sensitive, But in EF Core DB decides, it's LIKE %value%
            if (!string.IsNullOrWhiteSpace(request.Title))
            {
                movies = movies.Where(m =>
                    m.Title.Contains(request.Title));
            }

            // Duration
            if (request.Duration.HasValue)
            {
                var duration = TimeSpan.FromMinutes(request.Duration.Value);
                movies = movies.Where(m => m.Duration == duration);
            }


            // Actor. JOIN via MovieActor
            // Equals if wants exact match
            if (!string.IsNullOrWhiteSpace(request.ActorFirstName) ||
                !string.IsNullOrWhiteSpace(request.ActorLastName))
            {

                if (!string.IsNullOrWhiteSpace(request.ActorFirstName))
                {
                    actorQuery = actorQuery.Where(a =>
                        a.FirstName.Contains(request.ActorFirstName));
                }

                if (!string.IsNullOrWhiteSpace(request.ActorLastName))
                {
                    actorQuery = actorQuery.Where(a =>
                        a.LastName.Contains(request.ActorLastName));
                }

                var actorIds = actorQuery.Select(a => a.Id);

                movies = movies.Where(m =>
                    movieActorQuery.Any(ma =>
                        ma.MovieId == m.Id &&
                        actorIds.Contains(ma.ActorId)
                    ));
            }


            // Avoid nullable in DTO mapping
            // Send cancellation token to ToListAsync so when user close browser or navigates away
            // We wouldn't waste resources, reduce load under heavy traffic
            var result = await movies
                .OrderBy(m => m.Title)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
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
