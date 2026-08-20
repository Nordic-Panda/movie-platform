namespace MovieService.Application.Common.DTOs;

public record MovieDto(
    Guid Id,
    string Title,
    int DurationMinutes,
    IReadOnlyList<GenreDto> Genres,
    LanguageDto Language,
    int Year,
    string? Synopsis,
    decimal? BudgetAmount,
    string? CurrencyCode,
    string? PosterUrl
);
