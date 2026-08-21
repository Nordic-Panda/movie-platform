using MovieService.Domain.Common.Normalizers;
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

            var normalizedTitle = StringNormalizer.NormalizeTitle(title);

            MovieRules.ValidateTitleLength(normalizedTitle);
            MovieRules.ValidatePublishYear(year);
            MovieRules.ValidateDuration(duration);

            posterUrl = string.IsNullOrWhiteSpace(posterUrl)
                ? posterUrl
                : StringNormalizer.NormalizeDescription(posterUrl);

            return new Movie(normalizedTitle, year, duration, genres, details, language, posterUrl);
        }
    }
}
