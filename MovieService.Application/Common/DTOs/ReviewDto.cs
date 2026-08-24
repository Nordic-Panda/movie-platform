namespace MovieService.Application.Common.DTOs
{
    public record ReviewDto(
        Guid Id,
        Guid MovieId,
        string Comment,
        int Rating,
        string DisplayName,
        string Username
    );
}
