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
                movie.Genres.Select(GenreMapper.ToDto).ToList(),
                LanguageMapper.ToDto(movie.Language),
                movie.Year,
                movie.Details.Synopsis,
                movie.Details.Budget?.Amount,
                movie.Details.Budget?.Currency.Code,
                movie.PosterUrl
            );
        }
    }
}
