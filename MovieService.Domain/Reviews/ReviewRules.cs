using MovieService.Domain.Common.Exceptions;

namespace MovieService.Domain.Reviews
{
    public static class ReviewRules
    {
        public const int MinRating = 1;
        public const int MaxRating = 5;

        public static void ValidateRating(int rating)
        {
            if (rating < MinRating || rating > MaxRating)
                throw new DomainException(
                    ReviewErrors.InvalidRatingCode,
                    ReviewErrors.InvalidRatingMessage(MinRating, MaxRating)
                );
        }

        public static void ValidateComment(string comment)
        {
            if (string.IsNullOrWhiteSpace(comment))
                throw new DomainException(
                    ReviewErrors.CommentEmptyCode,
                    ReviewErrors.CommentEmptyMessage
                );
        }

        public static void ValidateMovieId(Guid movieId)
        {
            if (movieId == Guid.Empty)
                throw new DomainException(
                    ReviewErrors.MovieIdEmptyCode,
                    ReviewErrors.MovieIdEmptyMessage
                );
        }

        public static void ValidateUserId(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new DomainException(
                    ReviewErrors.UserIdEmptyCode,
                    ReviewErrors.UserIdEmptyMessage
                );
        }
    }
}
