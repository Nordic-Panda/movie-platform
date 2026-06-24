namespace MovieService.Domain.Currency
{
    public static class CurrencyErrors
    {
        public const string CurrencyCodeEmptyCode = "CURRENCY_CODE_EMPTY";
        public const string CurrencyCodeEmptyMessage = "Currency code cannot be empty.";

        public const string CurrencyNameEmptyCode = "CURRENCY_NAME_EMPTY";
        public const string CurrencyNameEmptyMessage = "Currency name cannot be empty.";

        public const string CurrencyDecimalInvalidCode = "CURRENCY_DECIMAL_INVALID";
        public const string CurrencyDecimalInvalidMessage = "Number of decimals must be between 0 and 8.";

        public const string CurrencyCodeInvalidLengthCode = "CURRENCY_CODE_INVALID_LENGTH";
        public const string CurrencyCodeInvalidLengthMessage = "Currency code must be exactly 3 characters.";
    }
}