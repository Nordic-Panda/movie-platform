using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Interfaces;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;

namespace MovieService.Application.Auth.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, UserDto>
    {
        private readonly IRegisterProviderResolver _providerResolver;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterHandler(IRegisterProviderResolver providerResolver, IUnitOfWork unitOfWork)
        {
            _providerResolver = providerResolver;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> Handle(
            RegisterCommand request,
            CancellationToken cancellationToken
        )
        {
            // Here we return a IRegisterProvider, but it's actually one of the Provider we have
            // thus when running resolve here, we are actually going to that Provider's resolve, like Local, Microsoft.

            // Polymorphism: the resolver returns the provider through the interface,
            // while the runtime object determines which RegisterAsync() implementation runs.
            var provider = _providerResolver.Resolve(request.Provider);

            var user = await provider.RegisterAsync(request, cancellationToken);

            await _unitOfWork.SaveChangesAsync();

            return UserMapper.ToDto(user);
        }
    }
}
