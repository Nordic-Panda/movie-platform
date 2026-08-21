using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Actors;

namespace MovieService.Application.Actors.CreateActor
{
    public class CreateActorHandler : IRequestHandler<CreateActorCommand, ActorDto>
    {
        private readonly IActorRepository _actorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateActorHandler(IActorRepository actorRepository, IUnitOfWork unitOfWork)
        {
            _actorRepository = actorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ActorDto> Handle(
            CreateActorCommand command,
            CancellationToken cancellationToken
        )
        {
            var actor = ActorFactory.Create(command.FirstName, command.LastName, command.BirthYear);
            await _actorRepository.AddAsync(actor);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return ActorMapper.ToDto(actor);
        }
    }
}
