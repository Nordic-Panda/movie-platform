using MovieService.Domain.Reviews;

namespace MovieService.Application.Common.Interfaces.Repositories
{
    public interface IReviewRepository
    {
        Task AddReviewAsync(Review review);

        Task SaveChangesAsync();

        Task<Review?> GetReviewById(Guid id);
    }
}
