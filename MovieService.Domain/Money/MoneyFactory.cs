using MovieService.Domain.Common.Exceptions;

namespace MovieService.Domain.Money
{
    public class MoneyFactory
    {
        public static ValueObjects.Money Create(decimal amount, string currency) 
        {
            if (amount < 0)
                throw new DomainException(
                    MoneyErrors.NegativeAmountCode,
                    MoneyErrors.NegativeAmountMessage);

            if (string.IsNullOrWhiteSpace(currency))
                throw new DomainException(
                    MoneyErrors.MissingCurrencyCode,
                    MoneyErrors.MissingCurrencyMessage);

            return new ValueObjects.Money(amount, currency.ToUpper());
        }
    }
}
