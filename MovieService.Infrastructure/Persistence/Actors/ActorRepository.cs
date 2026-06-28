using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Domain.Actors;
using MovieService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

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

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
