namespace MovieService.Domain.Exceptions
{
    public static class MoneyErrors
    {
        public const string NegativeAmountCode = ErrorCodes.MoneyNegative;
        public const string NegativeAmountMessage = "Money amount cannot be negative";

        public const string MissingCurrencyCode = ErrorCodes.MoneyCurrencyMissing;
        public const string MissingCurrencyMessage = "Currency is required";
    }
}