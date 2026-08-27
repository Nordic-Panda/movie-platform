namespace MovieService.Application.Common.DTOs
{
    public record UserDto(
        Guid Id,
        string Email,
        string Username,
        string DisplayName,
        DateTime CreatedAt
    );
}
