namespace MovieService.Domain.Exceptions
{
    public class MovieErrors
    {
        public const string MovieTitleEmptyCode = "MOVIE_EMPTY_TITLE";
        public const string MovieTitleEmptyMessage = "Title is required";

        public const string MovieDurationInvalidCode = "MOVIE_DURATION_INVALID";
        public const string MovieDurationInvalidMessage = "Duration must be greater than 0";

        public const string MovieGenreInvalidCode = "MOVIE_GENRE_INVALID";
        public const string MovieGenreInvalidMessage = "Genre is required";
    }
}
