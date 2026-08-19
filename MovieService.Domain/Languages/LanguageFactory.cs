using MovieService.Domain.Common.Exceptions;

namespace MovieService.Domain.Languages
{
    public static class LanguageFactory
    {
        public static Language Create(string name, string code)
        {
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
