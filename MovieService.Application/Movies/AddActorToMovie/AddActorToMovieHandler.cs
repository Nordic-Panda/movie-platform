using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.MovieActor;
namespace MovieService.Application.Movies.AddActorToMovie
{
    public class AddActorToMovieHandler : IRequestHandler<AddActorToMovieCommand, MovieActorDto>
    {
        private readonly IMovieActorRepository _movieActorRepository;

        public AddActorToMovieHandler(IMovieActorRepository movieActorRepository)
        {
            _movieActorRepository = movieActorRepository;
        }

        public async Task<MovieActorDto> Handle(AddActorToMovieCommand command, CancellationToken cancellationToken)
        {
            var movieActor = MovieActorFactory.Create(command.MovieId, command.ActorId, command.CharacterName);

            await _movieActorRepository.AddActorToMovieAsync(movieActor);

            return MovieActorMapper.ToDto(movieActor);
        }
    }
}
