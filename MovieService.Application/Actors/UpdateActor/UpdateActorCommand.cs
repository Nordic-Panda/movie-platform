using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Actors.UpdateActor
{
    public record UpdateActorCommand(Guid Id, string FirstName, string LastName, int BirthYear)
        : IRequest<ActorDto>;
}
