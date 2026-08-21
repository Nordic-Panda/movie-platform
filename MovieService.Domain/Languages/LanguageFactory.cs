using MovieService.Domain.Common.Normalizers;

namespace MovieService.Domain.Languages
{
    public static class LanguageFactory
    {
        public static Language Create(string name, string code)
        {
            // 2nd check, due to request might come from internally, skipping handler
            LanguageRules.ValidateName(name);
            LanguageRules.ValidateISOCode(code);

            var normalizedName = StringNormalizer.ToTitleCase(name);
            LanguageRules.ValidateNameLength(normalizedName);

            var normalizedCode = StringNormalizer.ToUpper(code);
            LanguageRules.ValidateISOCode(normalizedCode);

            return new Language(normalizedName, normalizedCode);
        }
    }
}
