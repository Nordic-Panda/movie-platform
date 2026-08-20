namespace MovieService.Domain.Common.Normalizers
{
    public static class StringNormalizer
    {
        public static string NormalizeName(string value)
        {
            return NormalizeWhitespace(value);
        }

        public static string NormalizeTitle(string value)
        {
            return NormalizeWhitespace(value);
        }

        public static string ToTitleCase(string value)
        {
            value = value.Trim();

            if (value.Length == 0)
                return value;

            return char.ToUpperInvariant(value[0]) + value[1..].ToLowerInvariant();
        }

        public static string ToUpper(string value)
        {
            return NormalizeWhitespace(value).ToUpperInvariant();
        }

        public static string ToLower(string value)
        {
            return NormalizeWhitespace(value).ToLowerInvariant();
        }

        private static string NormalizeWhitespace(string value)
        {
            return string.Join(" ", value.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
