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
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResult>
    {
        private readonly ILoginProviderResolver _providerResolver;
        private readonly IRoleRepository _roleRepository;
        private readonly ITokenService _tokenService;
        private readonly JwtSettings _jwtSettings;
        private readonly IExternalRegistrationTokenService _externalRegistrationTokenService;

        public LoginHandler(
            ILoginProviderResolver providerResolver,
            IRoleRepository roleRepository,
            ITokenService tokenService,
            IOptions<JwtSettings> options,
            IExternalRegistrationTokenService externalRegistrationTokenService
        )
        {
            _providerResolver = providerResolver;
            _roleRepository = roleRepository;
            _tokenService = tokenService;
            _jwtSettings = options.Value;
            _externalRegistrationTokenService = externalRegistrationTokenService;
        }

        public async Task<LoginResult> Handle(
            LoginCommand request,
            CancellationToken cancellationToken
        )
        {
            // Polymorphism.
            // Resolve the authentication provider at runtime.
            // The handler does not need to know how the selected provider authenticates the user.
            var provider = _providerResolver.Resolve(request.Provider);

            var result = await provider.AuthenticateAsync(request, cancellationToken);

            // External identity was successfully authenticated,
            // but it is not linked to a local User yet.
            // This indicates a first external login and requires registration.

            if (result.User is null && result.ExternalIdentity is not null)
            {
                var externalIdentity = result.ExternalIdentity;

                var registrationToken = _externalRegistrationTokenService.CreateToken(
                    externalIdentity
                );

                return new LoginResult(
                    RequiresRegistration: true,
                    AccessToken: null,
                    ExpiresInMinutes: null,
                    User: null,
                    ExternalRegistration: new ExternalRegistrationDto(
                        registrationToken,
                        externalIdentity.Provider,
                        externalIdentity.Email,
                        externalIdentity.DisplayName
                    )
                );
            }

            // The nullable analyzer cannot understand that User is non-null
            // after the external first-login branch, so we explicitly validate it here.

            var user =
                result.User
                ?? throw new UnauthorizedException(
                    UserErrors.AccountNotAvailableCode,
                    UserErrors.AccountNotAvailableMessage
                );

            var existingRole = await _roleRepository.GetRoleByIdAsync(user.RoleId);

            if (existingRole is null || !existingRole.IsActive)
            {
                throw new UnauthorizedException(
                    UserErrors.AccountNotAvailableCode,
                    UserErrors.AccountNotAvailableMessage
                );
            }

            var token = _tokenService.CreateToken(user, existingRole);

            var expiresInMinutes = _jwtSettings.ExpiresInMinutes;

            var userDto = UserMapper.ToDto(user);

            return new LoginResult(
                RequiresRegistration: false,
                AccessToken: token,
                ExpiresInMinutes: expiresInMinutes,
                User: userDto,
                ExternalRegistration: null
            );
        }
    }
}
