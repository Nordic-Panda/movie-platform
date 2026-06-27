using MovieService.Domain.Entities;
using MovieService.Domain.Movies;

namespace MovieService.Application.Common.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        Task AddAsync(Movie movie);
        Task<Movie?> GetByIdAsync(Guid id);
        Task<IReadOnlyList<Movie>> GetAllMoviesAsync();
        Task SaveChangesAsync();
    }
}