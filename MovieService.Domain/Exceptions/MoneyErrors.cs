namespace MovieService.Domain.Exceptions
{
    public static class MoneyErrors
    {
        public const string NegativeAmountCode = ErrorCodes.MoneyNegative;
        public const string NegativeAmountMessage = "Money amount cannot be negative";

        public const string InvalidCurrencyCode = ErrorCodes.MoneyCurrencyInvalid;
        public const string InvalidCurrencyMessage = "Currency is invalid";
    }
}