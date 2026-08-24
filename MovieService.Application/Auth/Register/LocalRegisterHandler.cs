using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Common.Enums;
using MovieService.Domain.Roles;
using MovieService.Domain.UserIdentities;
using MovieService.Domain.Users;

namespace MovieService.Application.Auth.Register
{
    public class LocalRegisterHandler : IRequestHandler<LocalRegisterCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserIdentityRepository _userIdentityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LocalRegisterHandler(
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IUserIdentityRepository userIdentityRepository,
            IUnitOfWork unitOfWork
        )
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userIdentityRepository = userIdentityRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> Handle(
            LocalRegisterCommand request,
            CancellationToken cancellationToken
        )
        {
            var existingEmail = await _userRepository.GetUserByEmailAsync(request.Email);

            if (existingEmail is not null)
                throw new ConflictException(
                    UserErrors.EmailExistsCode,
                    UserErrors.EmailExistsMessage
                );

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

            await _unitOfWork.SaveChangesAsync();

            return UserMapper.ToDto(user);
        }
    }
}
