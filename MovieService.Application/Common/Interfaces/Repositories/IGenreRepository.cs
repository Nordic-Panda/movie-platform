using MovieService.Domain.Genres;

namespace MovieService.Application.Common.Interfaces.Repositories
{
    public interface IGenreRepository
    {
        Task AddAsync(Genre genre);

        Task DeleteAsync(Guid id);

        Task<IReadOnlyList<Genre>> GetAllGenresAsync();
        Task<IReadOnlyList<Genre>> GetAllActiveGenresAsync();

        Task<Genre?> GetGenreByIdAsync(Guid id);
        Task<Genre?> GetActiveGenreByIdAsync(Guid id);

        Task<Genre?> GetGenreByNameAsync(string name);
        Task<Genre?> GetActiveGenreByNameAsync(string name);

        Task<IReadOnlyList<Genre>> GetGenresByIdsAsync(ICollection<Guid> ids);
        Task<IReadOnlyList<Genre>> GetActiveGenresByIdsAsync(ICollection<Guid> ids);

        void Update(Genre genre);

        IQueryable<Genre> Query();
    }
}
