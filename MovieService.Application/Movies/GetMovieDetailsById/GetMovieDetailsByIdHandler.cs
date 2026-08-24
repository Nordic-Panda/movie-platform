using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Movies;

namespace MovieService.Application.Movies.GetMovieDetailsById
{
    public class GetMovieDetailsByIdHandler
        : IRequestHandler<GetMovieDetailsByIdQuery, MovieDetailsDto>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMovieActorRepository _movieActorRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IReviewRepository _reviewRepository;

        public GetMovieDetailsByIdHandler(
            IMovieRepository movieRepository,
            IMovieActorRepository movieActorRepository,
            IActorRepository actorRepository,
            IReviewRepository reviewRepository
        )
        {
            _movieRepository = movieRepository;
            _movieActorRepository = movieActorRepository;
            _actorRepository = actorRepository;
            _reviewRepository = reviewRepository;
        }

        public async Task<MovieDetailsDto> Handle(
            GetMovieDetailsByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var movie = await _movieRepository.GetActiveMovieByIdAsync(request.Id);

            if (movie is null)
                throw new NotFoundException(
                    MovieErrors.MovieNotFoundCode,
                    MovieErrors.MovieNotFoundMessage
                );

            var movieActors = await _movieActorRepository.GetMovieActorsByMovieIdAsync(request.Id);

            var actorIds = movieActors.Select(x => x.ActorId).ToList();

            var actors =
                actorIds.Count == 0 ? [] : await _actorRepository.GetActorsByIdsAsync(actorIds);

            var reviews = await _reviewRepository.GetActiveReviewsByMovieId(request.Id);

            /*
                1st collection.Join(
                2nd collection,

                1st collection's key,
                2nd's key,

                what result do they produce
                )

                Note that key does not have to be ID, it's just an identifier
            */
            var cast = movieActors
                .Join(
                    actors,
                    movieActor => movieActor.ActorId,
                    actor => actor.Id,
                    (movieActor, actor) =>
                        new MovieCastDto(
                            actor.Id,
                            actor.FirstName,
                            actor.LastName,
                            actor.BirthYear,
                            movieActor.CharacterName
                        )
                )
                .ToList();

            return new MovieDetailsDto(
                movie.Id,
                movie.Title,
                movie.Year,
                (int)movie.Duration.TotalMinutes,
                movie.Details.Synopsis,
                movie.Details.Budget is not null ? MoneyMapper.ToDto(movie.Details.Budget) : null,
                LanguageMapper.ToDto(movie.Language),
                cast,
                reviews.Select(ReviewMapper.ToDto).ToList(),
                movie.PosterUrl
            );
        }
    }
}
