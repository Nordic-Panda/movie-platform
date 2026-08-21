using MovieService.Domain.Movies;

namespace MovieService.Application.Common.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        Task AddAsync(Movie movie);
        Task<IReadOnlyList<Movie>> GetAllMoviesAsync();
        Task<Movie?> GetMovieByIdAsync(Guid id);
        Task<Movie?> GetActiveMovieByIdAsync(Guid id);
        Task<Movie?> GetActiveMovieByTitleAndYearAndDurationAsync(
            string title,
            int year,
            TimeSpan duration
        );
        Task DeleteMovieAsync(Guid id);
        IQueryable<Movie> Query();
    }
}
