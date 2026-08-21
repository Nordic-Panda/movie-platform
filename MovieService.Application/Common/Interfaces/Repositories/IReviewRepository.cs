using MovieService.Domain.Reviews;

namespace MovieService.Application.Common.Interfaces.Repositories
{
    public interface IReviewRepository
    {
        Task AddReviewAsync(Review review);

        Task<Review?> GetReviewById(Guid id);
        Task<Review?> GetActiveReviewById(Guid id);

        Task<IReadOnlyList<Review>> GetReviewsByMovieId(Guid id);
        Task<IReadOnlyList<Review>> GetActiveReviewsByMovieId(Guid id);
    }
}
