namespace MovieService.Application.Common.DTOs
{
    public record ExternalRegistrationDto(
        string RegistrationToken,
        string Provider,
        string Email,
        string DisplayName
    );
}
