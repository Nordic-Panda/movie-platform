namespace MovieService.Domain.Language
{
    public static class LanguageErrors
    {
        public const string NameEmptyCode = "LANGUAGE_NAME_EMPTY";
        public const string NameEmptyMessage = "Language name cannot be empty";

        public const string ISOEmptyCode = "LANGUAGE_ISO_EMPTY";
        public const string ISOEmptyMessage = "Language ISO code cannot be empty";

        public const string NameTooShortCode = "LANGUAGE_NAME_TOO_SHORT";

        public static string NameTooShortMessage(int minLength) =>
            $"Language name must be longer than {minLength} characters";

        public const string NameTooLongCode = "LANGUAGE_NAME_TOO_LONG";

        public static string NameTooLongMessage(int maxLength) =>
            $"Language name must be shorter than {maxLength} characters";

        public const string ISOInvalidLengthCode = "LANGUAGE_ISO_INVALID_LENGTH";

        public static string ISOInvalidLengthMessage(int expectedLength) =>
            $"Language ISO code must be exactly {expectedLength} characters long";
    }
}
