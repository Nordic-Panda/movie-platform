using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Actors.CreateActor
{
    public record CreateActorCommand
    (
        string FirstName,
        string LastName,
        int BirthYear
    ) : IRequest<ActorDto>;
}
