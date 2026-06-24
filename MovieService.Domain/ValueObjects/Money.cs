using MovieService.Domain.Enums;
using MovieService.Domain.Exceptions;

namespace MovieService.Domain.ValueObjects
{
    public class Money
    {
        public decimal Amount { get; }
        public Currency Currency { get; }
        public Money(decimal amount, Currency currency)
        {
            if (amount < 0)
                throw new DomainException(MoneyErrors.NegativeAmountCode, MoneyErrors.NegativeAmountMessage);

            if (!Enum.IsDefined(typeof(Currency), currency))
                throw new DomainException(
                    MoneyErrors.InvalidCurrencyCode,
                    MoneyErrors.InvalidCurrencyMessage);

            Amount = amount;
            Currency = currency;
        }

        public static Money SEK(decimal amount) => new(amount, Currency.SEK);
        public static Money USD(decimal amount) => new(amount, Currency.USD);
    }
}
