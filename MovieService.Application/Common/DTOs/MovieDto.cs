namespace MovieService.Application.Common.DTOs;

public record MovieDto(
    Guid Id,
    string Title,
    int DurationMinutes,
    IReadOnlyList<GenreDto> Genres,
    string Language,
    string? Synopsis,
    decimal? BudgetAmount,
    string? CurrencyCode
);