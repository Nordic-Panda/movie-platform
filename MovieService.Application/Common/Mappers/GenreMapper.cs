using MovieService.Application.Common.DTOs;
using MovieService.Domain.Genres;

namespace MovieService.Application.Common.Mappers
{
    public static class GenreMapper
    {
        public static GenreDto ToDto(Genre genre)
        {
            return new GenreDto(
                genre.Id,
                genre.Name
            );
        }
    }
}
