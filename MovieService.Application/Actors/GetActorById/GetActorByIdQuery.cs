using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Actors.GetActorById
{
    public record GetActorByIdQuery(Guid Id) : IRequest<ActorDto>;
}
