using BCrypt.Net;
using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Users;

namespace MovieService.Application.Users.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResponseDto>
    {
        private readonly IUserRepository _userRepository;

        public LoginHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);

            if (user == null)
                throw new UnauthorizedException(UserErrors.CredentialInvalidCode, UserErrors.CredentialInvalidMessage);

            var passwordDoesMatch = BCrypt.Net.BCrypt.Verify(request.Password, user?.PasswordHash);

            if (!passwordDoesMatch)
                throw new UnauthorizedException(UserErrors.CredentialInvalidCode, UserErrors.CredentialInvalidMessage);


            // real accesstoken
            var accesstoken = "accesstoken dummy";
            int expiresIn = 1000;

            var dto = UserMapper.ToDto(user);

            return LoginResponseMapper.ToDto(accesstoken, expiresIn, dto);
        }
    }
}
