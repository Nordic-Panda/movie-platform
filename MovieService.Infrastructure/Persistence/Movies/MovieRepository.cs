using Microsoft.EntityFrameworkCore;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Domain.Movies;
using MovieService.Infrastructure.Data;

namespace MovieService.Infrastructure.Persistence.Movies
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
        }

        // THIS IS NOT USED, get all handler is now using query
        public async Task<IReadOnlyList<Movie>> GetAllMoviesAsync()
        {
            return await _context
                .Movies.Include(m => m.Genres)
                .Include(m => m.Language)
                .Include(m => m.Details)
                    .ThenInclude(d => d.Budget)
                        .ThenInclude(b => b.Currency)
                .ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(Guid id)
        {
            return await _context
                .Movies.Include(m => m.Genres)
                .Include(m => m.Language)
                .Include(m => m.Details)
                    .ThenInclude(d => d.Budget)
                        .ThenInclude(b => b.Currency)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _context.Movies.Where(m => m.Id == id).ExecuteDeleteAsync();
        }

        public IQueryable<Movie> Query()
        {
            return _context.Movies.AsQueryable();
        }
    }
}
