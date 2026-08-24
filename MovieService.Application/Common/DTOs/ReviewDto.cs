namespace MovieService.Application.Common.DTOs
{
    public record ReviewDto(
        Guid Id,
        Guid MovieId,
        Guid UserId,
        string Username,
        string DisplayName,
        string Comment,
        int Rating
    );
}
