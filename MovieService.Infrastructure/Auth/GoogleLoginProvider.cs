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
            if (string.IsNullOrWhiteSpace(command.Credential))
            {
                throw new UnauthorizedException(
                    UserErrors.CredentialInvalidCode,
                    UserErrors.CredentialInvalidMessage
                );
            }

            // Resolve the external authentication provider at runtime.
            // The login provider does not need to know how a specific external provider
            // validates credentials. This keeps provider-specific authentication isolated
            // and allows additional providers, such as Microsoft, to be added later.
            var authenticationProvider = _authenticationProviderResolver.Resolve(Provider);

            var externalIdentity = await authenticationProvider.AuthenticateAsync(
                command.Credential,
                cancellationToken
            );

            var existingIdentity = await _userIdentityRepository.GetByProviderAndSubjectAsync(
                externalIdentity.Provider,
                externalIdentity.Subject
            );

            // If authentication with the external provider succeeds but no matching
            // UserIdentity exists in our database, this is the user's first login.
            if (existingIdentity is null)
            {
                return new LoginProviderResult(User: null, ExternalIdentity: externalIdentity);
            }

            var existingUser = await _userRepository.GetUserByIdAsync(existingIdentity.UserId);

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
