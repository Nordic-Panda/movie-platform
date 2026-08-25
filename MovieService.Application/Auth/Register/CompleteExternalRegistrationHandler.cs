using MediatR;
using Microsoft.Extensions.Options;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Application.Common.Settings;
using MovieService.Domain.Roles;
using MovieService.Domain.UserIdentities;
using MovieService.Domain.Users;

namespace MovieService.Application.Auth.Register
{
    public class CompleteExternalRegistrationHandler
        : IRequestHandler<CompleteExternalRegistrationCommand, LoginResponseDto>
    {
        private readonly IExternalRegistrationTokenService _externalRegistrationTokenService;

        private readonly IUserRepository _userRepository;
        private readonly IUserIdentityRepository _userIdentityRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly JwtSettings _jwtSettings;

        public CompleteExternalRegistrationHandler(
            IExternalRegistrationTokenService externalRegistrationTokenService,
            IUserRepository userRepository,
            IUserIdentityRepository userIdentityRepository,
            IRoleRepository roleRepository,
            IUnitOfWork unitOfWork,
            ITokenService tokenService,
            IOptions<JwtSettings> options
        )
        {
            _externalRegistrationTokenService = externalRegistrationTokenService;

            _userRepository = userRepository;
            _userIdentityRepository = userIdentityRepository;
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _jwtSettings = options.Value;
        }

        public async Task<LoginResponseDto> Handle(
            CompleteExternalRegistrationCommand request,
            CancellationToken cancellationToken
        )
        {
            // instead of trusting FE info, here we get info from Token
            var externalIdentity = _externalRegistrationTokenService.ValidateToken(
                request.RegistrationToken
            );

            var existingIdentity = await _userIdentityRepository.GetByProviderAndSubjectAsync(
                externalIdentity.Provider,
                externalIdentity.Subject
            );

            if (existingIdentity is not null)
                throw new ConflictException(
                    UserErrors.AccountAlreadyExistsCode,
                    UserErrors.AccountAlreadyExistsMessage
                );

            var existingUsername = await _userRepository.GetUserByUsernameAsync(request.Username);

            if (existingUsername is not null)
                throw new ConflictException(
                    UserErrors.UsernameExistsCode,
                    UserErrors.UsernameExistsMessage
                );

            var role = await _roleRepository.GetDefaultRoleAsync();

            if (role is null || !role.IsActive)
                throw new NotFoundException(
                    RoleErrors.DefaultRoleNotFoundCode,
                    RoleErrors.DefaultRoleNotFoundMessage
                );

            var user = UserFactory.Create(
                externalIdentity.Email,
                request.Username,
                externalIdentity.DisplayName,
                role.Id
            );

            var identity = UserIdentityFactory.CreateExternal(
                user.Id,
                externalIdentity.Provider,
                externalIdentity.Subject
            );

            await _userRepository.AddAsync(user);
            await _userIdentityRepository.AddAsync(identity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var token = _tokenService.CreateToken(user, role);

            var expiresInMinutes = _jwtSettings.ExpiresInMinutes;

            var userDto = UserMapper.ToDto(user);

            return LoginResponseMapper.ToAuthenticatedDto(token, expiresInMinutes, userDto);
        }
    }
}
