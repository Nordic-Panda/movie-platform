using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Domain.Movies;
using MovieService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
            await _context.SaveChangesAsync();
        }

        public async Task<Movie?> GetByIdAsync(Guid id)
        {
            return await _context.Movies
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}