using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Movies.UpdateMovie
{
    public record UpdateMovieCommand(
        Guid Id,
        string? Title,
        int? DurationMinutes,
        ICollection<Guid>? GenreIds,
        Guid? LanguageId,
        int? Year,
        string? Synopsis,
        decimal? BudgetAmount,
        string? CurrencyCode,
        string? PosterUrl
    ) : IRequest<MovieDto>;
}
