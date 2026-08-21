using MediatR;
using Microsoft.Extensions.Options;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Application.Common.Settings;
using MovieService.Domain.Users;

namespace MovieService.Application.Users.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly JwtSettings _jwtSettings;
        private readonly IRoleRepository _roleRepository;

        public LoginHandler(
            IUserRepository userRepository,
            ITokenService tokenService,
            IOptions<JwtSettings> options,
            IRoleRepository roleRepository
        )
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _jwtSettings = options.Value;
            _roleRepository = roleRepository;
        }

        public async Task<LoginResponseDto> Handle(
            LoginCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);

            if (user is null)
                throw new UnauthorizedException(
                    UserErrors.CredentialInvalidCode,
                    UserErrors.CredentialInvalidMessage
                );

            if (!user.IsActive)
                throw new UnauthorizedException(
                    UserErrors.AccountNotAvailableCode,
                    UserErrors.AccountNotAvailableMessage
                );

            var passwordDoesMatch = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

            if (!passwordDoesMatch)
                throw new UnauthorizedException(
                    UserErrors.CredentialInvalidCode,
                    UserErrors.CredentialInvalidMessage
                );

            var role = await _roleRepository.GetRoleByIdAsync(user.RoleId);

            if (role is null || !role.IsActive)
            {
                throw new UnauthorizedException(
                    UserErrors.AccountNotAvailableCode,
                    UserErrors.AccountNotAvailableMessage
                );
            }

            // JWT is CPU work, no need await
            var token = _tokenService.CreateToken(user, role);
            var expiresInMinutes = _jwtSettings.ExpiresInMinutes;

            var dto = UserMapper.ToDto(user);

            return LoginResponseMapper.ToDto(token, expiresInMinutes, dto);
        }
    }
}
