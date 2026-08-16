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

        public async Task Delete(Guid id)
        {
            await _context.Genres.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<IReadOnlyList<Genre>> GetAllGenresAsync()
        {
            return (await _context.Genres.ToListAsync())
                .AsReadOnly();
        }

        public async Task<Genre?> GetByIdAsync(Guid id)
        {
            return await _context.Genres
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Genre>> GetByIdsAsync(ICollection<Guid> ids)
        {
            return (await _context.Genres
                .Where(x => ids.Contains(x.Id))
                .ToListAsync())
                .AsReadOnly();
        }

        public void Update(Genre genre)
        {
            _context.Genres.Update(genre);
        }
    }
}
