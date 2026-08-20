namespace MovieService.Domain.Moneies
{
    public static class MoneyErrors
    {
        public const string NegativeAmountCode = "NEGATIVE_AMOUNT";
        public const string NegativeAmountMessage = "Money amount cannot be negative";

        public const string MissingCurrencyCode = "MISSING_CURRENCY";
        public const string MissingCurrencyMessage = "Currency is required";
    }
}
