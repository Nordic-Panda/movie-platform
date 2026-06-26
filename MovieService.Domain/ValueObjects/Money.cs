using MovieService.Domain.Enums;
using MovieService.Domain.Exceptions;
using MovieService.Domain.Money;

namespace MovieService.Domain.ValueObjects
{
    public class Money
    {
        public decimal Amount { get; }
        public string Currency { get; }

        private Money() { }
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

        // can have a add, Value object is Data + rules + domain behavior
    }
}
