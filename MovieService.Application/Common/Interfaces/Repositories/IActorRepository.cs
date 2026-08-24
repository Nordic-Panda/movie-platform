using MovieService.Domain.Actors;

namespace MovieService.Application.Common.Interfaces.Repositories
{
    public interface IActorRepository
    {
        Task AddAsync(Actor actor);

        Task<IReadOnlyList<Actor>> GetAllActorsAsync();
        Task<IReadOnlyList<Actor>> GetAllActiveActorsAsync();

        Task<Actor?> GetActorByIdAsync(Guid id);
        Task<Actor?> GetActiveActorByIdAsync(Guid id);

        Task<IReadOnlyList<Actor>> GetActorsByIdsAsync(IReadOnlyList<Guid> ids);

        IQueryable<Actor> Query();
    }
}
