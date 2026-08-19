namespace MovieService.Application.Common.Normalizers
{
    public static class StringNormalizer
    {
        public static string ToTitleCase(string value)
        {
            value = value.Trim();

            if (value.Length == 0)
                return value;

            return char.ToUpperInvariant(value[0]) + value[1..].ToLowerInvariant();
        }

        public static string ToUpper(string value)
        {
            return value.Trim().ToUpperInvariant();
        }
    }
}
