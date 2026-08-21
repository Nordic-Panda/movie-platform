using MovieService.Domain.Common.Normalizers;

namespace MovieService.Domain.Reviews
{
    public static class ReviewFactory
    {
        public static Review Create(Guid movieId, string comment, int rating)
        {
            ReviewRules.ValidateRating(rating);
            ReviewRules.ValidateComment(comment);

            var normalizedComment = StringNormalizer.NormalizeDescription(comment);

            return new Review(movieId, normalizedComment, rating);
        }
    }
}
