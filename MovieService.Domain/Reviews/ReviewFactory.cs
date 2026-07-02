using MovieService.Domain.Common.Exceptions;

namespace MovieService.Domain.Reviews
{
    public static class ReviewFactory
    {
        public static Review Create(Guid movieId, string comment, int rating) 
        {

            if (rating < ReviewRules.MinRating ||
                rating > ReviewRules.MaxRating)
            {
                throw new DomainException(
                    ReviewErrors.InvalidRatingCode,
                    ReviewErrors.InvalidRatingMessage(ReviewRules.MinRating, ReviewRules.MaxRating));
            }

            return new Review(Guid.NewGuid(), movieId, comment, rating);
        }
    }
}
