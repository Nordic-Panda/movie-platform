using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Movies.CreateMovie;

public record CreateMovieCommand(
    string Title,
    int DurationMinutes,
    ICollection<Guid> GenreIds,
    Guid LanguageId,
    int Year,
    string? Synopsis,
    decimal? BudgetAmount,
    string? CurrencyCode
) : IRequest<MovieDto>;
