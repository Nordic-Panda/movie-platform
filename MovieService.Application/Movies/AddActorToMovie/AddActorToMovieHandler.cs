using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Actors;
using MovieService.Domain.MovieActor;
using MovieService.Domain.Movies;
namespace MovieService.Application.Movies.AddActorToMovie
{
    public class AddActorToMovieHandler : IRequestHandler<AddActorToMovieCommand, MovieActorDto>
    {
        private readonly IMovieActorRepository _movieActorRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IActorRepository _actorRepository;

        public AddActorToMovieHandler(IMovieActorRepository movieActorRepository, IMovieRepository movieRepository, IActorRepository actorRepository)
        {
            _movieActorRepository = movieActorRepository;
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
        }

        public async Task<MovieActorDto> Handle(AddActorToMovieCommand command, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetByIdAsync(command.MovieId);

            if (movie == null)
                throw new NotFoundException(MovieErrors.MovieNotFoundCode, MovieErrors.MovieNotFoundMessage);

            var actor = await _actorRepository.GetByIdAsync(command.ActorId);

            if (actor == null)
                throw new NotFoundException(ActorErrors.ActorNotFoundCode, ActorErrors.ActorNotFoundMessage);

            var movieActor = MovieActorFactory.Create(command.MovieId, command.ActorId, command.CharacterName);

            await _movieActorRepository.AddActorToMovieAsync(movieActor);
            await _movieActorRepository.SaveChangesAsync();

            return MovieActorMapper.ToDto(movieActor);
        }
    }
}
