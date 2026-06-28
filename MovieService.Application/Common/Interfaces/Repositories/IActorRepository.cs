using MovieService.Domain.Actors;

namespace MovieService.Application.Common.Interfaces.Repositories
{
    public interface IActorRepository
    {
        Task AddAsync(Actor actor);

        Task SaveChangesAsync();
    }
}
