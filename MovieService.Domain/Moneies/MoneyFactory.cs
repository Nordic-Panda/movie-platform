using MovieService.Domain.Currencies;
using MovieService.Domain.ValueObjects;

namespace MovieService.Domain.Moneies
{
    public class MoneyFactory
    {
        public static Money Create(decimal amount, Currency currency)
        {
            MoneyRules.ValidateBudgetAmount(amount);

            return new Money(amount, currency);
        }
    }
}
