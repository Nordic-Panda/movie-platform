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
            return (await _context.Actors.ToListAsync()).AsReadOnly();
        }

        public async Task<Actor?> GetByIdAsync(Guid id)
        {
            return await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
