using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Auth.Login
{
    // This is not a response to FE, this is between application and controller
    public record LoginResult(
        bool RequiresRegistration,
        string? AccessToken,
        int? ExpiresInMinutes,
        UserDto? User,
        ExternalRegistrationDto? ExternalRegistration
    );
}
