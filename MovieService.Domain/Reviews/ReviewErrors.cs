namespace MovieService.Domain.Reviews
{
    public class ReviewErrors
    {
        public const string InvalidRatingCode = "REVIEW_INVALID_RATING";

        public static string InvalidRatingMessage(int minRate, int maxRate) =>
            $"Review rating must be between {minRate} and {maxRate}.";

        public const string ReviewNotFoundCode = "REVIEW_NOT_FOUND";
        public const string ReviewNotFoundMessage = "No review found";

        public const string CommentEmptyCode = "COMMENT_EMPTY";
        public const string CommentEmptyMessage = "Comment can not be empty";

        public const string MovieIdEmptyCode = "MOVIE_ID_EMPTY";
        public const string MovieIdEmptyMessage = "Please select a movie";
    }
}
