using MovieService.Domain.Movies;

namespace MovieService.Application.Common.DTOs
{
    public record MoneyDto(
        decimal? Amount,
        string? Currency
    );
}
