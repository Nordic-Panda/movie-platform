using Microsoft.EntityFrameworkCore;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Domain.Actors;
using MovieService.Infrastructure.Data;

namespace MovieService.Infrastructure.Persistence.Actors
{
    public class ActorRepository : IActorRepository
    {
        private readonly AppDbContext _context;

        public ActorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
        }

        public async Task<IReadOnlyList<Actor>> GetAllActorsAsync()
        {
            return await _context.Actors.AsNoTracking().ToListAsync();
        }

        public async Task<IReadOnlyList<Actor>> GetAllActiveActorsAsync()
        {
            return await _context.Actors.Where(a => a.IsActive).AsNoTracking().ToListAsync();
        }

        public async Task<Actor?> GetActorByIdAsync(Guid id)
        {
            return await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Actor?> GetActiveActorByIdAsync(Guid id)
        {
            return await _context.Actors.FirstOrDefaultAsync(a => a.Id == id && a.IsActive);
        }

        public async Task<IReadOnlyList<Actor>> GetActorsByIdsAsync(IReadOnlyList<Guid> ids)
        {
            return await _context.Actors.Where(a => ids.Contains(a.Id)).ToListAsync();
        }

        public IQueryable<Actor> Query()
        {
            return _context.Actors.AsQueryable();
        }
    }
}
