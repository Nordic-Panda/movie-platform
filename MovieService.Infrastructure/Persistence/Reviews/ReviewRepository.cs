using Microsoft.EntityFrameworkCore;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Domain.Reviews;
using MovieService.Infrastructure.Data;

namespace MovieService.Infrastructure.Persistence.Reviews
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;

        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddReviewAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
        }

        public async Task<Review?> GetReviewById(Guid id)
        {
            return await _context.Reviews.FirstOrDefaultAsync(review => review.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
