namespace MovieService.Domain.Exceptions
{
    public class ReviewErrors
    {
        public const string ReviewInvalidRatingCode = "REVIEW_INVALID_RATING";
        public const string ReviewInvalidRatingMessage = "Review rating must be between 1 and 5";
    }
}
