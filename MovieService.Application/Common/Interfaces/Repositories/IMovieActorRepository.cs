using MovieService.Domain.MovieActors;

namespace MovieService.Application.Common.Interfaces.Repositories
{
    public interface IMovieActorRepository
    {
        Task AddActorToMovieAsync(MovieActor movieActor);
        IQueryable<MovieActor> Query();
    }
}
