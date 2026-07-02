using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Domain.Common.Enums;

namespace MovieService.Application.Movies.CreateMovie;

public record CreateMovieCommand(
    string Title,
    int DurationMinutes,
    Genre Genre,
    string Language,
    string? Synopsis,
    decimal? BudgetAmount,
    string? CurrencyCode
) : IRequest<MovieDto>;