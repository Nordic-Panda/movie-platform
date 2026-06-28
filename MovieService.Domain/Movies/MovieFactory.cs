using MovieService.Domain.Enums;
using MovieService.Domain.Exceptions;
using MovieService.Domain.ValueObjects;

namespace MovieService.Domain.Movies
{
    public static class MovieFactory
    {
        public static Movie Create(
            string title,
            TimeSpan duration,
            Genre genre,
            MovieDetails details)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new DomainException(
                    ActorErrors.TitleEmptyCode,
                    ActorErrors.TitleEmptyMessage);

            if (title.Length < MovieRules.TitleMinLength)
                throw new DomainException(
                    ActorErrors.TitleTooShortCode,
                    ActorErrors.TitleTooShortMessage(MovieRules.TitleMinLength));

            if (title.Length > MovieRules.TitleMaxLength)
                throw new DomainException(
                    ActorErrors.TitleTooLongCode,
                    ActorErrors.TitleTooLongMessage(MovieRules.TitleMaxLength));

            if (duration < MovieRules.MinDuration)
                throw new DomainException(
                    ActorErrors.DurationTooShortCode,
                    ActorErrors.DurationTooShortMessage((int)MovieRules.MinDuration.TotalMinutes));

            if (duration > MovieRules.MaxDuration)
                throw new DomainException(
                    ActorErrors.DurationTooLongCode,
                    ActorErrors.DurationTooLongMessage((int)MovieRules.MinDuration.TotalMinutes));

            if (!Enum.IsDefined(genre))
                throw new DomainException(
                    ActorErrors.GenreInvalidCode,
                    ActorErrors.GenreInvalidMessage);

            return new Movie(
                Guid.NewGuid(),
                title,
                duration,
                genre,
                details);
        }
    }
}