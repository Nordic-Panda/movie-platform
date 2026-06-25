using MovieService.Domain.Entities;
using MovieService.Domain.Movies;

namespace MovieService.Application.Movies.CreateMovie
{
    public interface IMovieRepository
    {
        Task AddAsync(Movie movie);
    }
}