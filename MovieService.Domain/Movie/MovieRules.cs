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
}
