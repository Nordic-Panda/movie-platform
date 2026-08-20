using MovieService.Domain.Common.Exceptions;

namespace MovieService.Domain.Movies;

public static class MovieRules
{
    public const int TitleMinLength = 2;
    public const int TitleMaxLength = 200;

    public static readonly TimeSpan MinDuration = TimeSpan.FromMinutes(1);
    public static readonly TimeSpan MaxDuration = TimeSpan.FromMinutes(600);

    public const int MinYear = 1888;

    public static bool IsValidYear(int year, int currentYear)
    {
        return year >= MinYear && year <= currentYear;
    }

    public static void ValidateTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException(MovieErrors.TitleEmptyCode, MovieErrors.TitleEmptyMessage);

        if (title.Length < TitleMinLength)
            throw new DomainException(
                MovieErrors.TitleTooShortCode,
                MovieErrors.TitleTooShortMessage(TitleMinLength)
            );

        if (title.Length > TitleMaxLength)
            throw new DomainException(
                MovieErrors.TitleTooLongCode,
                MovieErrors.TitleTooLongMessage(TitleMaxLength)
            );
    }

    public static void ValidatePublishYear(int year)
    {
        if (!IsValidYear(year, DateTime.UtcNow.Year))
            throw new DomainException(
                MovieErrors.YearInvalidCode,
                MovieErrors.YearInvalidMessage(MinYear, DateTime.UtcNow.Year)
            );
    }

    public static void ValidateDuration(TimeSpan duration)
    {
        if (duration < MinDuration)
            throw new DomainException(
                MovieErrors.DurationTooShortCode,
                MovieErrors.DurationTooShortMessage((int)MinDuration.TotalMinutes)
            );

        if (duration > MaxDuration)
            throw new DomainException(
                MovieErrors.DurationTooLongCode,
                MovieErrors.DurationTooLongMessage((int)MaxDuration.TotalMinutes)
            );
    }
}
