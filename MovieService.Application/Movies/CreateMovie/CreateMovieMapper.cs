using MovieService.Application.Common.DTOs;
using MovieService.Domain.Movies;

namespace MovieService.Application.Movies.CreateMovie
{
    public static class CreateMovieMapper
    {
        public static MovieDto ToDto(Movie movie)
        {
            return new MovieDto(
                movie.Id,
                movie.Title,
                (int)movie.Duration.TotalMinutes,
                movie.Genre.ToString(),
                movie.Details.Language,
                movie.Details.Synopsis,
                movie.Details.Budget?.Amount,
                movie.Details.Budget?.Currency
            );
        }
    }
}