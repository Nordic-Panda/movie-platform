namespace MovieService.Application.Common.DTOs
{
    public record LoginResponseDto(
        string AccessToken,
        int ExpiresInMinutes,
        UserDto User
    );
}
