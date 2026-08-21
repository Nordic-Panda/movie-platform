using Microsoft.EntityFrameworkCore;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Domain.Genres;
using MovieService.Infrastructure.Data;

namespace MovieService.Infrastructure.Persistence.Genres
{
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext _context;

        public GenreRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
        }

        // AVOID! Is Now Using Soft Delete/Hide/Deactive
        public async Task DeleteAsync(Guid id)
        {
            await _context.Genres.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<IReadOnlyList<Genre>> GetAllGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<IReadOnlyList<Genre>> GetAllActiveGenresAsync()
        {
            return await _context.Genres.Where(g => g.IsActive).ToListAsync();
        }

        public async Task<Genre?> GetGenreByIdAsync(Guid id)
        {
            return await _context.Genres.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Genre?> GetActiveGenreByIdAsync(Guid id)
        {
            return await _context.Genres.FirstOrDefaultAsync(g => g.Id == id && g.IsActive);
        }

        public async Task<Genre?> GetGenreByNameAsync(string name)
        {
            return await _context.Genres.FirstOrDefaultAsync(g => g.Name == name);
        }

        public async Task<Genre?> GetActiveGenreByNameAsync(string name)
        {
            return await _context.Genres.FirstOrDefaultAsync(g => g.Name == name && g.IsActive);
        }

        public async Task<IReadOnlyList<Genre>> GetGenresByIdsAsync(ICollection<Guid> ids)
        {
            return await _context.Genres.Where(g => ids.Contains(g.Id)).ToListAsync();
        }

        public async Task<IReadOnlyList<Genre>> GetActiveGenresByIdsAsync(ICollection<Guid> ids)
        {
            return await _context.Genres.Where(g => ids.Contains(g.Id) && g.IsActive).ToListAsync();
        }

        public void Update(Genre genre)
        {
            _context.Genres.Update(genre);
        }

        public IQueryable<Genre> Query()
        {
            return _context.Genres.AsQueryable();
        }
    }
}
