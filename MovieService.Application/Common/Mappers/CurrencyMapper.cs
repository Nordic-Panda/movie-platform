using MovieService.Application.Common.DTOs;
using MovieService.Domain.Currencies;

namespace MovieService.Application.Common.Mappers
{
    public static class CurrencyMapper
    {
        public static CurrencyDto ToDto(Currency currency)
        {
            return new CurrencyDto(currency.Name, currency.Code);
        }
    }
}
