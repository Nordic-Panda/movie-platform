namespace MovieService.Application.Reviews.CreateReview
{
    public record CreateReviewRequest(Guid UserId, string Comment, int Rating);
}
