namespace MovieService.Application.Common.DTOs
{
    public record CreateMovieRequest(
        string Title,
        int DurationMinutes,
        string Genre,
        string Language,
        string? Synopsis,
        decimal? BudgetAmount,
        string? CurrencyCode
    );
}
