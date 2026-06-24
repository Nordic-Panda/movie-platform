using MovieService.Domain.Enums;
using MovieService.Domain.Exceptions;

namespace MovieService.Domain.ValueObjects
{
    public class Money
    {
        public decimal Amount { get; }
        public string Currency { get; }
        public Money(decimal amount, string currency)
        {
            if (amount < 0)
                throw new DomainException(
                    MoneyErrors.NegativeAmountCode,
                    MoneyErrors.NegativeAmountMessage);

            if (string.IsNullOrWhiteSpace(currency))
                throw new DomainException(
                    MoneyErrors.MissingCurrencyCode,
                    MoneyErrors.MissingCurrencyMessage);

            Amount = amount;
            Currency = currency;
        }
    }
}
