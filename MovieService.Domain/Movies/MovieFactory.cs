using MovieService.Domain.Genres;
using MovieService.Domain.Languages;
using MovieService.Domain.ValueObjects;

namespace MovieService.Domain.Movies
{
    public static class MovieFactory
    {
        public static Movie Create(
            string title,
            int year,
            TimeSpan duration,
            IReadOnlyCollection<Genre> genres,
            MovieDetail details,
            Language language,
            string? posterUrl
        )
        {
            MovieRules.ValidateTitle(title);
            MovieRules.ValidatePublishYear(year);
            MovieRules.ValidateDuration(duration);

            return new Movie(title, year, duration, genres, details, language, posterUrl);
        }
    }
}
