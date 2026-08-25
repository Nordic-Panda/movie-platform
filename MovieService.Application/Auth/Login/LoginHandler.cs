using MediatR;
using Microsoft.Extensions.Options;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Application.Common.Settings;
using MovieService.Domain.Users;

namespace MovieService.Application.Auth.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResponseDto>
    {
        private readonly ILoginProviderResolver _providerResolver;
        private readonly IRoleRepository _roleRepository;
        private readonly ITokenService _tokenService;
        private readonly JwtSettings _jwtSettings;

        public LoginHandler(
            ILoginProviderResolver providerResolver,
            IRoleRepository roleRepository,
            ITokenService tokenService,
            IOptions<JwtSettings> options
        )
        {
            _providerResolver = providerResolver;
            _roleRepository = roleRepository;
            _tokenService = tokenService;
            _jwtSettings = options.Value;
        }

        public async Task<LoginResponseDto> Handle(
            LoginCommand request,
            CancellationToken cancellationToken
        )
        {
            // Polymorphism.
            // Resolve the authentication provider at runtime.
            // The handler does not need to know how the selected provider authenticates the user.
            var provider = _providerResolver.Resolve(request.Provider);

            var result = await provider.AuthenticateAsync(request, cancellationToken);

            // If an external identity was successfully authenticated,
            // but it is not linked to a local User yet.
            // This indicates a first external login and requires registration.
            if (result.User is null && result.ExternalIdentity is not null)
            {
                var externalIdentity = result.ExternalIdentity!;

                return LoginResponseMapper.ToRegistrationRequiredDto(
                    new ExternalRegistrationDto(
                        externalIdentity.Provider,
                        externalIdentity.Email,
                        externalIdentity.DisplayName
                    )
                );
            }

            var existingRole = await _roleRepository.GetRoleByIdAsync(result.User.RoleId);

            if (existingRole is null || !existingRole.IsActive)
            {
                throw new UnauthorizedException(
                    UserErrors.AccountNotAvailableCode,
                    UserErrors.AccountNotAvailableMessage
                );
            }

            var token = _tokenService.CreateToken(result.User, existingRole);

            var expiresInMinutes = _jwtSettings.ExpiresInMinutes;

            var userDto = UserMapper.ToDto(result.User);

            return LoginResponseMapper.ToAuthenticatedDto(token, expiresInMinutes, userDto);
        }
    }
}
