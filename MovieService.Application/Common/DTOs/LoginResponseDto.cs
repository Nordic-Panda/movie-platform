namespace MovieService.Application.Common.DTOs
{
    public record LoginResponseDto(
        string AccessToken,
        int ExpiresIn,
        UserDto User
    );
}
