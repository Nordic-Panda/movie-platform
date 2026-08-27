namespace MovieService.Application.Common.DTOs
{
    public record LoginResponseDto(
        bool RequiresRegistration,
        int? ExpiresInMinutes,
        UserDto? User,
        ExternalRegistrationDto? ExternalRegistration
    );
}
