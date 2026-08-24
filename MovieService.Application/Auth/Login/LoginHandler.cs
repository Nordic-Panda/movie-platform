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
            var provider = _providerResolver.Resolve(request.Provider);

            var user = await provider.AuthenticateAsync(request, cancellationToken);

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

            return LoginResponseMapper.ToDto(token, expiresInMinutes, userDto);
        }
    }
}
