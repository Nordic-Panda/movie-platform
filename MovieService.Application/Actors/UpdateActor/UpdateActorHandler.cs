using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Actors;

namespace MovieService.Application.Actors.UpdateActor
{
    public class UpdateActorHandler : IRequestHandler<UpdateActorCommand, ActorDto>
    {
        private readonly IActorRepository _actorRepository;

        public UpdateActorHandler(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }
        public async Task<ActorDto> Handle(UpdateActorCommand request, CancellationToken cancellationToken)
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
