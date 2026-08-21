using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Actors;

namespace MovieService.Application.Actors.GetActorById
{
    public class GetActorByIdHandler : IRequestHandler<GetActorByIdQuery, ActorDto>
    {
        private readonly IActorRepository _actorRepository;

        public GetActorByIdHandler(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task<ActorDto> Handle(
            GetActorByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var actor = await _actorRepository.GetActiveActorByIdAsync(request.Id);

            return actor is null
                ? throw new NotFoundException(
                    ActorErrors.ActorNotFoundCode,
                    ActorErrors.ActorNotFoundMessage
                )
                : ActorMapper.ToDto(actor);
        }
    }
}
