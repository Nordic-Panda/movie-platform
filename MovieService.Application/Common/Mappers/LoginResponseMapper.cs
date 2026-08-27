using MovieService.Application.Auth.Login;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Common.Mappers
{
    public static class LoginResponseMapper
    {
        public static LoginResponseDto ToAuthenticatedDto(int expiresInMinutes, UserDto user)
        {
            return new LoginResponseDto(
                RequiresRegistration: false,
                ExpiresInMinutes: expiresInMinutes,
                User: user,
                ExternalRegistration: null
            );
        }

        public static LoginResponseDto ToRegistrationRequiredDto(
            ExternalRegistrationDto externalRegistration
        )
        {
            return new LoginResponseDto(
                RequiresRegistration: true,
                ExpiresInMinutes: null,
                User: null,
                ExternalRegistration: externalRegistration
            );
        }

        public static LoginResponseDto ToDto(LoginResult result)
        {
            return new LoginResponseDto(
                result.RequiresRegistration,
                result.ExpiresInMinutes,
                result.User,
                result.ExternalRegistration
            );
        }
    }
}
