using MovieService.Application.Common.DTOs;
using MovieService.Domain.ValueObjects;

namespace MovieService.Application.Common.Mappers
{
    public class MoneyMapper
    {
        public static MoneyDto ToDto(Money money)
        {
            return new MoneyDto(money.Amount, money.Currency.Name, money.Currency.Code);
        }
    }
}
