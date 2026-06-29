using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Actors.PutActor
{
    public record PutActorCommand
    (
        Guid Id,
        string FirstName,
        string LastName,
        int BirthYear
    ) : IRequest<ActorDto>;
}
