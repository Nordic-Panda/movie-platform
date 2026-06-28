using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;

namespace MovieService.Application.Actors.GetActors
{
    public class GetActorsHandler : IRequestHandler<GetActorsQuery, IReadOnlyList<ActorDto>>
    {
        private readonly IActorRepository _actorRepository;

        public GetActorsHandler(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task<IReadOnlyList<ActorDto>> Handle(GetActorsQuery request, CancellationToken cancellationToken)
        {
            var actors = await _actorRepository.GetAllActorsAsync();
            return actors
                .Select(ActorMapper.ToDto)
                .ToList()
                .AsReadOnly();
        }
    }
}
