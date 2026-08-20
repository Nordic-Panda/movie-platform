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

        public async Task DeleteAsync(Guid id)
        {
            await _context.Movies.Where(m => m.Id == id).ExecuteDeleteAsync();
        }

        // THIS WAS NOT USED
        public async Task<IReadOnlyList<Movie>> GetAllMoviesAsync()
        {
            return (
                await _context
                    .Movies.Include(x => x.Genres)
                    .Include(m => m.Language)
                    .Include(x => x.Details)
                        .ThenInclude(x => x.Budget)
                            .ThenInclude(x => x.Currency)
                    .ToListAsync()
            ).AsReadOnly();
        }

        public async Task<Movie?> GetByIdAsync(Guid id)
        {
            return await _context
                .Movies.Include(x => x.Genres)
                .Include(x => x.Language)
                .Include(x => x.Details)
                    .ThenInclude(x => x.Budget)
                        .ThenInclude(x => x.Currency)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Movie> Query()
        {
            return _context.Movies.AsQueryable();
        }
    }
}
