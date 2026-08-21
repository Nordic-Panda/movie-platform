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
        private readonly IUnitOfWork _unitOfWork;

        public UpdateActorHandler(IActorRepository actorRepository, IUnitOfWork unitOfWork)
        {
            _actorRepository = actorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ActorDto> Handle(
            UpdateActorCommand request,
            CancellationToken cancellationToken
        )
        {
            var existingActor = await _actorRepository.GetActiveActorByIdAsync(request.Id);

            if (existingActor is null)
                throw new NotFoundException(
                    ActorErrors.ActorNotFoundCode,
                    ActorErrors.ActorNotFoundMessage
                );

            existingActor.Update(request.FirstName, request.LastName, request.BirthYear);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return ActorMapper.ToDto(existingActor);
        }
    }
}
