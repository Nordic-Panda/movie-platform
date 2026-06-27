namespace MovieService.Domain.ValueObjects
{
    public class Money
    {
        public decimal Amount { get; }
        public string Currency { get; }

        private Money() { }
        internal Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        // can have a add, Value object is Data + rules + domain behavior
    }
}
