using MovieService.Domain.Currencies;

namespace MovieService.Domain.ValueObjects
{
    public class Money
    {
        public decimal Amount { get; }
        public Currency Currency { get; }

        private Money() { }

        internal Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        // can have a add, Value object is Data + rules + domain behavior
    }
}
