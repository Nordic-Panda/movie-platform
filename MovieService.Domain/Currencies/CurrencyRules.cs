using MovieService.Domain.Common.Exceptions;

namespace MovieService.Domain.Currencies
{
    public class CurrencyRules
    {
        public const int MinDecimal = 0;
        public const int MaxDecimal = 2;

        public const int IsoCodeLength = 3;

        public const int NameMaxLength = 100;

        public static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException(
                    CurrencyErrors.NameEmptyCode,
                    CurrencyErrors.NameEmptyMessage
                );
        }

        public static void ValidateCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new DomainException(
                    CurrencyErrors.CodeEmptyCode,
                    CurrencyErrors.CodeEmptyMessage
                );
        }

        public static void ValidateLength(string name, string code)
        {
            if (name.Length > NameMaxLength)
                throw new DomainException(
                    CurrencyErrors.NameTooLongCode,
                    CurrencyErrors.NameTooLongMessage(NameMaxLength)
                );

            if (code.Length != IsoCodeLength)
                throw new DomainException(
                    CurrencyErrors.CodeInvalidLengthCode,
                    CurrencyErrors.CodeInvalidLengthMessage(IsoCodeLength)
                );
        }
    }
}
