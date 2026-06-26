namespace MovieService.Domain.Movies;

public static class MovieRules
{
    public const int TitleMinLength = 2;
    public const int TitleMaxLength = 200;

    public static readonly TimeSpan MinDuration = TimeSpan.FromMinutes(1);
    public static readonly TimeSpan MaxDuration = TimeSpan.FromMinutes(600);
}