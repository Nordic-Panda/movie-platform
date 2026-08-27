namespace MovieService.Application.Common.DTOs
{
    public record LoginResponseDto(
        bool RequiresRegistration,
        string? AccessToken,
        int? ExpiresInMinutes,
        UserDto? User,
        ExternalRegistrationDto? ExternalRegistration
    );
}
