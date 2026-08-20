using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Currencies.GetCurrencies
{
    public record GetCurrenciesQuery : IRequest<IReadOnlyList<CurrencyDto>>;
}
