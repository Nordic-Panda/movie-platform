using MovieService.Domain.MovieActors;

namespace MovieService.Application.Common.Interfaces.Repositories
{
    public interface IMovieActorRepository
    {
        Task AddActorToMovieAsync(MovieActor movieActor);
        Task<IReadOnlyList<MovieActor>> GetMovieActorsByMovieIdAsync(Guid movieId);
        IQueryable<MovieActor> Query();
    }
}
