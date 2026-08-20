namespace MovieService.Domain.Currencies
{
    public static class CurrencyErrors
    {
        public const string CodeEmptyCode = "CURRENCY_CODE_EMPTY";
        public const string CodeEmptyMessage = "Currency code cannot be empty.";

        public const string CodeInvalidLengthCode = "CURRENCY_CODE_INVALID_LENGTH";

        public static string CodeInvalidLengthMessage(int length) =>
            $"Currency code must be exactly {length} characters.";

        public const string NameEmptyCode = "CURRENCY_NAME_EMPTY";
        public const string NameEmptyMessage = "Currency name cannot be empty.";

        public const string NameTooLongCode = "NAME_TOO_LONG";

        public static string NameTooLongMessage(int maxLength) =>
            $"Currency Name can not exceed {maxLength} characters";

        public const string DecimalTooSmallCode = "CURRENCY_DECIMAL_TOO_SMALL_INVAVID";

        public static string DecimalTooSmallMessage(int minLength) =>
            $"Currency decimal must be bigger than {minLength}.";

        public const string DecimalTooBigCode = "CURRENCY_DECIMAL_TOO_BIG_INVAVID";

        public static string DecimalTooBigMessage(int maxLength) =>
            $"Crrency decimal must be smaller than {maxLength}.";
    }
}
