using MovieService.Domain.Common.Exceptions;
using MovieService.Domain.Common.Normalizers;

namespace MovieService.Domain.Languages
{
    public static class LanguageFactory
    {
        public static Language Create(string name, string code)
        {
            // 2nd check, due to request might come from internally, skipping handler
            name = StringNormalizer.ToTitleCase(name);
            code = StringNormalizer.ToUpper(code);

            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException(
                    LanguageErrors.NameEmptyCode,
                    LanguageErrors.NameEmptyMessage
                );

            name = name.Trim();

            LanguageRules.ValidateName(name);

            if (string.IsNullOrWhiteSpace(code))
                throw new DomainException(
                    LanguageErrors.ISOEmptyCode,
                    LanguageErrors.ISOEmptyMessage
                );

            code = code.Trim().ToUpperInvariant();

            LanguageRules.ValidateISOCode(code);

            return new Language(name, code);
        }
    }
}
