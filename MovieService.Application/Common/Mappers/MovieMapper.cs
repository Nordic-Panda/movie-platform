using MovieService.Application.Common.DTOs;
using MovieService.Domain.Movies;

namespace MovieService.Application.Common.Mappers
{
    public static class MovieMapper
    {
        public static MovieDto ToDto(Movie movie)
        {
            return new MovieDto(
                movie.Id,
                movie.Title,
                (int)movie.Duration.TotalMinutes,
                movie.Genres.Select(genre => new GenreDto(genre.Id, genre.Name)).ToList(),
                movie.Language.Name,
                movie.Language.Code,
                movie.Year,
                movie.Details.Synopsis,
                movie.Details.Budget?.Amount,
                movie.Details.Budget?.Currency.Code
            );
        }
    }
}
