using MovieService.Application.Common.DTOs;
using MovieService.Domain.Movies;

namespace MovieService.Application.Common.Mappers
{
    public class MoneyMapper
    {
        public static MoneyDto ToDto(Movie movie)
        {
            return new MoneyDto(
                movie.Details.Budget?.Amount,
                movie.Details.Budget?.Currency.Name,
                movie.Details.Budget?.Currency.Code
            );
        }
    }
}
