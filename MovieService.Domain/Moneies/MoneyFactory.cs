using MovieService.Domain.Common.Exceptions;
using MovieService.Domain.Currencies;
using MovieService.Domain.ValueObjects;

namespace MovieService.Domain.Moneies
{
    public class MoneyFactory
    {
        public static Money Create(decimal amount, Currency currency)
        {
            if (amount < 0)
                throw new DomainException(
                    MoneyErrors.NegativeAmountCode,
                    MoneyErrors.NegativeAmountMessage
                );

            if (currency is null)
                throw new DomainException(
                    MoneyErrors.MissingCurrencyCode,
                    MoneyErrors.MissingCurrencyMessage
                );

            return new Money(amount, currency);
        }
    }
}
