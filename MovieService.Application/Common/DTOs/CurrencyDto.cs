namespace MovieService.Application.Common.DTOs
{
    // Not including id because Code and Name are both unique
    public record CurrencyDto(string Name, string Code);
}
