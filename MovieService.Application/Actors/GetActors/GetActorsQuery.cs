using MediatR;
using MovieService.Application.Common.DTOs;
namespace MovieService.Application.Actors.GetActors
{
    public record GetActorsQuery
    (

    ) : IRequest<IReadOnlyList<ActorDto>>;
}
