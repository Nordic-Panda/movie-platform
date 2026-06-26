using MovieService.Application.Common.DTOs;
using MovieService.Domain.Enums;
using MovieService.Domain.Money;
using MovieService.Domain.Movies;
using MovieService.Domain.ValueObjects;

namespace MovieService.Application.Movies.CreateMovie
{
    public static class CreateMovieFactory
    {
        public static Movie Create(CreateMovieCommand request)
        {
            var genre = request.Genre;
            var duration = TimeSpan.FromMinutes(request.DurationMinutes);

            var money = request.BudgetAmount.HasValue && !string.IsNullOrEmpty(request.CurrencyCode)
                ? new Money(request.BudgetAmount.Value, request.CurrencyCode)
                : null;

            var details = new MovieDetails(
                request.Language,
                request.Synopsis,
                money
            );

            return MovieFactory.Create(
                request.Title,
                duration,
                genre,
                details
            );
        }
    }
}