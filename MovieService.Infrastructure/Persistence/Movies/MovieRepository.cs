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

        public async Task<Movie?> AddAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<IReadOnlyList<Movie>> GetAllMoviesAsync()
        {
            return (await _context.Movies.ToListAsync())
                .AsReadOnly();
        }

        public async Task<Movie?> GetByIdAsync(Guid id)
        {
            return await _context.Movies
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}