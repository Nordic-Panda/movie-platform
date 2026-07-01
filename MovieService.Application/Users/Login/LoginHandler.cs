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

        public LoginHandler(IUserRepository userRepository, ITokenService tokenService, IOptions<JwtSettings> options)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _jwtSettings = options.Value;
        }

        public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);

            if (user == null)
                throw new UnauthorizedException(UserErrors.CredentialInvalidCode, UserErrors.CredentialInvalidMessage);

            var passwordDoesMatch = BCrypt.Net.BCrypt.Verify(request.Password, user?.PasswordHash);

            if (!passwordDoesMatch)
                throw new UnauthorizedException(UserErrors.CredentialInvalidCode, UserErrors.CredentialInvalidMessage);

            // JWT is CPU work, no need await
            var token = _tokenService.CreateToken(user);
            var expiresInMinutes = _jwtSettings.ExpiresInMinutes;

            var dto = UserMapper.ToDto(user);

            return LoginResponseMapper.ToDto(token, expiresInMinutes, dto);
        }
    }
}
