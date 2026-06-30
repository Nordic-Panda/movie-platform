using Microsoft.EntityFrameworkCore;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Domain.Entities;
using MovieService.Infrastructure.Data;
namespace MovieService.Infrastructure.Persistence.MovieActors
{
    public class MovieActorRepository : IMovieActorRepository
    {
        private readonly AppDbContext _appDbContext;

        public MovieActorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddActorToMovieAsync(MovieActor movieActor)
        {
            await _appDbContext.MovieActor.AddAsync(movieActor);
        }

        public async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<MovieActor> Query()
        {
            return _appDbContext.MovieActor.AsQueryable();
        }
    }
}
