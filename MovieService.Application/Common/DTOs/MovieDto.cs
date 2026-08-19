namespace MovieService.Application.Common.DTOs;

public record MovieDto(
    Guid Id,
    string Title,
    int DurationMinutes,
    IReadOnlyList<GenreDto> Genres,
    string LanguageName,
    string LanguageCode,
    int Year,
    string? Synopsis,
    decimal? BudgetAmount,
    string? CurrencyCode
);
