using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Actors;

namespace MovieService.Application.Actors.PutActor
{
    public class PutActorHandler : IRequestHandler<PutActorCommand, ActorDto>
    {
        private readonly IActorRepository _actorRepository;

        public PutActorHandler(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }
        public async Task<ActorDto> Handle(PutActorCommand request, CancellationToken cancellationToken)
        {
            var actor = await _actorRepository.GetByIdAsync(request.Id);

            if (actor == null)
                throw new NotFoundException(ActorErrors.ActorNotFoundCode, ActorErrors.ActorNotFoundMessage);

            actor.Update(request.FirstName, request.LastName, request.BirthYear);

            await _actorRepository.SaveChangesAsync();

            return ActorMapper.ToDto(actor);
        }
    }
}
