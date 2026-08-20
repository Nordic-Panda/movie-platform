using MovieService.Domain.Common.Exceptions;

namespace MovieService.Domain.Languages
{
    public static class LanguageRules
    {
        public const int ISO6391Length = 2;
        public const int NameMaxLength = 100;
        public const int NameMinLength = 3;

        public static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException(
                    LanguageErrors.NameEmptyCode,
                    LanguageErrors.NameEmptyMessage
                );
        }

        public static void ValidateNameLength(string name)
        {
            if (name.Length < NameMinLength)
                throw new DomainException(
                    LanguageErrors.NameTooShortCode,
                    LanguageErrors.NameTooShortMessage(NameMinLength)
                );

            if (name.Length > NameMaxLength)
                throw new DomainException(
                    LanguageErrors.NameTooLongCode,
                    LanguageErrors.NameTooLongMessage(NameMaxLength)
                );
        }

        public static void ValidateISOCode(string isoCode)
        {
            if (string.IsNullOrWhiteSpace(isoCode))
                throw new DomainException(
                    LanguageErrors.ISOEmptyCode,
                    LanguageErrors.ISOEmptyMessage
                );
        }

        public static void ValidateISOCodeLength(string isoCode)
        {
            if (isoCode.Length != ISO6391Length)
                throw new DomainException(
                    LanguageErrors.ISOInvalidLengthCode,
                    LanguageErrors.ISOInvalidLengthMessage(ISO6391Length)
                );
        }
    }
}
