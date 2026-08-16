using MovieService.Domain.Common.Exceptions;
using MovieService.Domain.Genres;
using MovieService.Domain.ValueObjects;

namespace MovieService.Domain.Movies
{
    public static class MovieFactory
    {
        public static Movie Create(
            string title,
            TimeSpan duration,
            IReadOnlyCollection<Genre> genres,
            MovieDetails details)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new DomainException(
                    MovieErrors.TitleEmptyCode,
                    MovieErrors.TitleEmptyMessage);

            if (title.Length < MovieRules.TitleMinLength)
                throw new DomainException(
                    MovieErrors.TitleTooShortCode,
                    MovieErrors.TitleTooShortMessage(MovieRules.TitleMinLength));

            if (title.Length > MovieRules.TitleMaxLength)
                throw new DomainException(
                    MovieErrors.TitleTooLongCode,
                    MovieErrors.TitleTooLongMessage(MovieRules.TitleMaxLength));

            if (duration < MovieRules.MinDuration)
                throw new DomainException(
                    MovieErrors.DurationTooShortCode,
                    MovieErrors.DurationTooShortMessage((int)MovieRules.MinDuration.TotalMinutes));

            if (duration > MovieRules.MaxDuration)
                throw new DomainException(
                    MovieErrors.DurationTooLongCode,
                    MovieErrors.DurationTooLongMessage((int)MovieRules.MinDuration.TotalMinutes));

            return new Movie(
                Guid.NewGuid(),
                title,
                duration,
                genres,
                details);
        }
    }
}