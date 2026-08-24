using MovieService.Domain.Common.Normalizers;

namespace MovieService.Domain.Reviews
{
    public static class ReviewFactory
    {
        public static Review Create(Guid movieId, Guid userId, string comment, int rating)
        {
            ReviewRules.ValidateRating(rating);
            ReviewRules.ValidateComment(comment);
            ReviewRules.ValidateMovieId(movieId);
            ReviewRules.ValidateUserId(userId);

            var normalizedComment = StringNormalizer.NormalizeDescription(comment);

            return new Review(movieId, userId, normalizedComment, rating);
        }
    }
}
