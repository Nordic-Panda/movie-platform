using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Domain.MovieActors;
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

        public IQueryable<MovieActor> Query()
        {
            return _appDbContext.MovieActor.AsQueryable();
        }
    }
}
