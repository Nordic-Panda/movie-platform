namespace MovieService.Application.Common.DTOs
{
    public record MovieDetailsDto(
        Guid Id,
        string Title,
        int Year,
        int DurationMinutes,
        string? Synopsis,
        MoneyDto? Budget,
        LanguageDto Language,
        IReadOnlyList<MovieCastDto> Cast,
        IReadOnlyList<ReviewDto> Reviews,
        decimal? AverageRating,
        int ReviewCount,
        string? PosterUrl,
        DateTime CreatedAt
    );
}
