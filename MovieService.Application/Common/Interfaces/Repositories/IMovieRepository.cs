using MovieService.Domain.Movies;

namespace MovieService.Application.Common.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        Task AddAsync(Movie movie);
        Task<IReadOnlyList<Movie>> GetAllMoviesAsync();
        Task<Movie?> GetByIdAsync(Guid id);
        Task DeleteAsync(Guid id);
        IQueryable<Movie> Query();
    }
}
