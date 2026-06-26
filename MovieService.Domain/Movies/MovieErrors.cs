namespace MovieService.Domain.Movies
{
    public class MovieErrors
    {
        public const string MovieTitleEmptyCode = "MOVIE_EMPTY_TITLE";
        public const string MovieTitleEmptyMessage = "Title is required";

        public const string MovieGenreInvalidCode = "MOVIE_GENRE_INVALID";
        public const string MovieGenreInvalidMessage = "Genre is required";

        public const string MovieLanguageInvalidCode = "MOVIE_LANGUAGE_INVALID";
        public const string MovieLanguageInvalidMessage = "Language is required";


        public const string MovieTitleTooShortCode = "MOVE_TITLE_TOO_SHORT_INVAVID";
        public static string MovieTitleTooShortMessage(int minLength)
            => $"Movie title must be at least {minLength} characters.";

        public const string MovieTitleTooLongCode = "MOVE_TITLE_TOO_LONG_INVAVID";
        public static string MovieTitleTooLongMessage(int maxLength)
            => $"Movie title cannot exceed {maxLength} characters.";


        public const string MovieDurationTooShortCode = "MOVIE_DURATION_TOO_SHORT";
        public static string MovieDurationTooShortMessage(int minMinutes)
            => $"Movie duration must be at least {minMinutes} minutes.";

        public const string MovieDurationTooLongCode = "MOVIE_DURATION_TOO_LONG";
        public static string MovieDurationTooLongMessage(int maxMinutes)
            => $"Movie duration cannot exceed {maxMinutes} minutes.";
    }
}
