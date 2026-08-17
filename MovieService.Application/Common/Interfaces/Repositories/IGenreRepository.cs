using MovieService.Domain.Genres;

namespace MovieService.Application.Common.Interfaces.Repositories
{
    public interface IGenreRepository
    {
        Task<Genre?> GetByIdAsync(
            Guid id);

        Task<IReadOnlyList<Genre>> GetAllGenresAsync();

        Task<IReadOnlyList<Genre>> GetByIdsAsync(
            ICollection<Guid> ids);

        Task AddAsync(
            Genre genre);

        void Update(Genre genre);

        Task Delete(Guid id);

        Task<Genre?> GetByNameAsync(string name);

        IQueryable<Genre> Query();
    }
}
