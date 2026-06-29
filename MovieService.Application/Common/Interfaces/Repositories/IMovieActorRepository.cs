using MovieService.Domain.Entities;

namespace MovieService.Application.Common.Interfaces.Repositories
{
    public interface IMovieActorRepository
    {
        Task AddActorToMovieAsync(MovieActor movieActor);
        Task SaveChangesAsync();
    }
}
