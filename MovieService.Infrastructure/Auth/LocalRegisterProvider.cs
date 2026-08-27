using MovieService.Application.Auth.Register;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Domain.Auth;
using MovieService.Domain.Common.Exceptions;
using MovieService.Domain.Roles;
using MovieService.Domain.UserIdentities;
using MovieService.Domain.Users;

namespace MovieService.Infrastructure.Auth
{
    public class LocalRegisterProvider : IRegisterProvider
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserIdentityRepository _userIdentityRepository;

        public string Provider => IdentityProviders.Local;

        public LocalRegisterProvider(
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IUserIdentityRepository userIdentityRepository
        )
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userIdentityRepository = userIdentityRepository;
        }

        public async Task<User> RegisterAsync(
            RegisterCommand request,
            CancellationToken cancellationToken
        )
        {
            if (
                string.IsNullOrWhiteSpace(request.Email)
                || string.IsNullOrWhiteSpace(request.Username)
                || string.IsNullOrWhiteSpace(request.DisplayName)
                || string.IsNullOrWhiteSpace(request.Password)
            )
            {
                throw new DomainException(
                    UserErrors.CredentialInvalidCode,
                    UserErrors.CredentialInvalidMessage
                );
            }

            var existingEmail = await _userRepository.GetUserByEmailAsync(request.Email);

            if (existingEmail is not null)
            {
                throw new ConflictException(
                    UserErrors.EmailExistsCode,
                    UserErrors.EmailExistsMessage
                );
            }

            var existingUsername = await _userRepository.GetUserByUsernameAsync(request.Username);

            if (existingUsername is not null)
            {
                throw new ConflictException(
                    UserErrors.UsernameExistsCode,
                    UserErrors.UsernameExistsMessage
                );
            }

            var role = await _roleRepository.GetDefaultRoleAsync();

            if (role is null || !role.IsActive)
            {
                throw new NotFoundException(
                    RoleErrors.DefaultRoleNotFoundCode,
                    RoleErrors.DefaultRoleNotFoundMessage
                );
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = UserFactory.Create(
                request.Email,
                request.Username,
                request.DisplayName,
                role.Id
            );

            var identity = UserIdentityFactory.CreateLocal(user.Id, passwordHash);

            await _userRepository.AddAsync(user);
            await _userIdentityRepository.AddAsync(identity);

            return user;
        }
    }
}
