using MovieService.Application.Auth.Login;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Domain.UserIdentities;
using MovieService.Domain.Users;

namespace MovieService.Infrastructure.Auth
{
    public class LocalLoginProvider : ILoginProvider
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserIdentityRepository _userIdentityRepository;

        public string Provider => IdentityProviders.Local;

        public LocalLoginProvider(
            IUserRepository userRepository,
            IUserIdentityRepository userIdentityRepository
        )
        {
            _userRepository = userRepository;
            _userIdentityRepository = userIdentityRepository;
        }

        public async Task<User> AuthenticateAsync(
            LoginCommand command,
            CancellationToken cancellationToken
        )
        {
            if (
                string.IsNullOrWhiteSpace(command.Email)
                || string.IsNullOrWhiteSpace(command.Password)
            )
            {
                throw new UnauthorizedException(
                    UserErrors.CredentialInvalidCode,
                    UserErrors.CredentialInvalidMessage
                );
            }

            var existingUser = await _userRepository.GetUserByEmailAsync(command.Email);

            if (existingUser is null)
            {
                throw new UnauthorizedException(
                    UserErrors.CredentialInvalidCode,
                    UserErrors.CredentialInvalidMessage
                );
            }

            if (!existingUser.IsActive)
            {
                throw new UnauthorizedException(
                    UserErrors.AccountNotAvailableCode,
                    UserErrors.AccountNotAvailableMessage
                );
            }

            var existingIdentity = await _userIdentityRepository.GetByProviderAndSubjectAsync(
                IdentityProviders.Local,
                existingUser.Id.ToString()
            );

            if (existingIdentity is null || existingIdentity.PasswordHash is null)
            {
                throw new UnauthorizedException(
                    UserErrors.CredentialInvalidCode,
                    UserErrors.CredentialInvalidMessage
                );
            }

            var passwordDoesMatch = BCrypt.Net.BCrypt.Verify(
                command.Password,
                existingIdentity.PasswordHash
            );

            if (!passwordDoesMatch)
            {
                throw new UnauthorizedException(
                    UserErrors.CredentialInvalidCode,
                    UserErrors.CredentialInvalidMessage
                );
            }

            return existingUser;
        }
    }
}
