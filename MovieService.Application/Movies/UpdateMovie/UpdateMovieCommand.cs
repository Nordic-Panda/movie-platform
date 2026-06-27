using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Domain.Enums;

namespace MovieService.Application.Movies.UpdateMovie
{
    public record UpdateMovieCommand(
        Guid Id,
        string Title,
        int DurationMinutes,
        Genre Genre,
        string Language,
        string? Synopsis,
        decimal? BudgetAmount,
        string? CurrencyCode
    ) : IRequest<MovieDto>;
}
