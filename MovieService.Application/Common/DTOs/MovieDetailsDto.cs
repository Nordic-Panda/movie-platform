namespace MovieService.Application.Common.DTOs
{
    public record MovieDetailsDto(
        string Language,
        string? Synopsis,
        MoneyDto? Budget
    );
}
