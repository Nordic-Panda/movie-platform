using MovieService.Domain.Currencies;
using MovieService.Domain.Genres;
using MovieService.Domain.Languages;
using MovieService.Domain.Moneies;
using MovieService.Domain.MovieDetails;
using MovieService.Domain.Movies;
using MovieService.Domain.ValueObjects;

namespace MovieService.Application.Movies.CreateMovie
{
    public static class CreateMovieFactory
    {
        public static Movie Create(
            CreateMovieCommand request,
            IReadOnlyCollection<Genre> genres,
            Language language,
            Currency? currency
        )
        {
            var duration = TimeSpan.FromMinutes(request.DurationMinutes);

            Money? money = null;

            if (request.BudgetAmount.HasValue && currency is not null)
            {
                money = MoneyFactory.Create(request.BudgetAmount.Value, currency);
            }

            var details = MovieDetailFactory.Create(request.Synopsis, money);

            var posterUrl = string.IsNullOrWhiteSpace(request.PosterUrl) ? null : request.PosterUrl;

            return MovieFactory.Create(
                request.Title,
                request.Year,
                duration,
                genres,
                details,
                language,
                posterUrl
            );
        }
    }
}
