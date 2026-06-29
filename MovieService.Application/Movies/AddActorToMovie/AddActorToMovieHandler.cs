using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Interfaces.Repositories;
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


            var movieActor = await _movieActorRepository.AddActorToMovieAsync();
            throw new NotImplementedException();
        }
    }
}
