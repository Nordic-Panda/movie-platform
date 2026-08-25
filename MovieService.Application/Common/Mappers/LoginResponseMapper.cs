using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Common.Mappers
{
    public static class LoginResponseMapper
    {
        public static LoginResponseDto ToAuthenticatedDto(
            string accessToken,
            int expiresInMinutes,
            UserDto user
        )
        {
            return new LoginResponseDto(
                RequiresRegistration: false,
                AccessToken: accessToken,
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
                AccessToken: null,
                ExpiresInMinutes: null,
                User: null,
                ExternalRegistration: externalRegistration
            );
        }
    }
}
