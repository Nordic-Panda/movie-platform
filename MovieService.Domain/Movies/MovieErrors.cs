namespace MovieService.Domain.Movies
{
    public class MovieErrors
    {
        public const string TitleEmptyCode = "MOVIE_EMPTY_TITLE";
        public const string TitleEmptyMessage = "Movie title is required";

        public const string GenreInvalidCode = "MOVIE_GENRE_INVALID";
        public const string GenreInvalidMessage = "Movie genre is required";

        public const string LanguageInvalidCode = "MOVIE_LANGUAGE_INVALID";
        public const string LanguageInvalidMessage = "Movie language is required";


        public const string TitleTooShortCode = "MOVE_TITLE_TOO_SHORT_INVAVID";
        public static string TitleTooShortMessage(int minLength)
            => $"Movie title must be at least {minLength} characters.";

        public const string TitleTooLongCode = "MOVE_TITLE_TOO_LONG_INVAVID";
        public static string TitleTooLongMessage(int maxLength)
            => $"Movie title cannot exceed {maxLength} characters.";


        public const string DurationTooShortCode = "MOVIE_DURATION_TOO_SHORT";
        public static string DurationTooShortMessage(int minMinutes)
            => $"Movie duration must be at least {minMinutes} minutes.";

        public const string DurationTooLongCode = "MOVIE_DURATION_TOO_LONG";
        public static string DurationTooLongMessage(int maxMinutes)
            => $"Movie duration cannot exceed {maxMinutes} minutes.";

        public const string MovieNotFoundCode = "MOVIE_NOT_FOUND";
        public const string MovieNotFoundMessage = "Movie not found";
    }
}
