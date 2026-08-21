namespace MovieService.Application.Common.DTOs
{
    public record MoneyDto(decimal? Amount, string? CurrencyName, string? CurrencyCode);
}
