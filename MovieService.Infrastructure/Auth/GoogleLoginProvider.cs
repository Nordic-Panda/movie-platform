using MovieService.Application.Auth.Login;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Domain.UserIdentities;
using MovieService.Domain.Users;

namespace MovieService.Infrastructure.Auth
{
    public class GoogleLoginProvider : ILoginProvider
    {
        private readonly IExternalAuthenticationProviderResolver _authenticationProviderResolver;
        private readonly IUserIdentityRepository _userIdentityRepository;
        private readonly IUserRepository _userRepository;

        public string Provider => IdentityProviders.Google;

        public GoogleLoginProvider(
            IUserIdentityRepository userIdentityRepository,
            IUserRepository userRepository,
            IExternalAuthenticationProviderResolver authenticationProviderResolver
        )
        {
            _userIdentityRepository = userIdentityRepository;
            _userRepository = userRepository;
            _authenticationProviderResolver = authenticationProviderResolver;
        }

        public async Task<LoginProviderResult> AuthenticateAsync(
            LoginCommand command,
            CancellationToken cancellationToken
        )
        {
            // Resolve the external authentication provider at runtime.
            // This allows the login flow to work with different external providers
            // without knowing their implementations.
            // Currently external is only Google, but what if we have Microsoft and others? Scalability
            var authenticationProvider = _authenticationProviderResolver.Resolve(Provider);

            var externalIdentity = await authenticationProvider.AuthenticateAsync(
                command.Credential!,
                cancellationToken
            );

            var identity = await _userIdentityRepository.GetByProviderAndSubjectAsync(
                externalIdentity.Provider,
                externalIdentity.Subject
            );

            // If there is no identity in DB, but authenticated by 3rd party provider
            // meanning it's first login
            if (identity is null)
            {
                return new LoginProviderResult(User: null, ExternalIdentity: externalIdentity);
            }

            var existingUser = await _userRepository.GetUserByIdAsync(identity.UserId);

            if (existingUser is null)
            {
                throw new UnauthorizedException(
                    UserErrors.AccountNotAvailableCode,
                    UserErrors.AccountNotAvailableMessage
                );
            }

            if (!existingUser.IsActive)
            {
                throw new UnauthorizedException(
                    UserErrors.AccountNotAvailableCode,
                    UserErrors.AccountNotAvailableMessage
                );
            }

            return new LoginProviderResult(User: existingUser, ExternalIdentity: null);
        }
    }
}
