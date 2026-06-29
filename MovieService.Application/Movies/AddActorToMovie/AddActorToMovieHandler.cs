using MediatR;
using MovieService.Application.Common.DTOs;
namespace MovieService.Application.Movies.AddActorToMovie
{
    internal class AddActorToMovieHandler : IRequestHandler<AddActorToMovieCommand, MovieActorDto>
    {
        public Task<MovieActorDto> Handle(AddActorToMovieCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
        }
    }
}
