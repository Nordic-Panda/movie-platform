using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Movies.AddActorToMovie
{
    public record AddActorToMovieCommand
    (
        Guid MovieId,
        Guid ActorId,
        string CharacterName
    ) : IRequest<MovieActorDto>;
}
