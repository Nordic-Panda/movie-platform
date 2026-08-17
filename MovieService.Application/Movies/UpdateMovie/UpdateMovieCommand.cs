using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Movies.UpdateMovie
{
    public record UpdateMovieCommand(
        Guid Id,
        string Title,
        int DurationMinutes,
        ICollection<Guid> GenreIds,
        string Language,
        string? Synopsis,
        decimal? BudgetAmount,
        string? CurrencyCode
    ) : IRequest<MovieDto>;
}
