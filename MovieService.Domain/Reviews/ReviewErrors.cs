namespace MovieService.Domain.Reviews
{
    public class ReviewErrors
    {
        public const string InvalidRatingCode = "REVIEW_INVALID_RATING";
        public const string InvalidRatingMessage = "Review rating must be between 1 and 5";
    }
}
