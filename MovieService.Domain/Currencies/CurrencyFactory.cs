using MovieService.Domain.Common.Exceptions;
using MovieService.Domain.Common.Normalizers;

namespace MovieService.Domain.Currencies
{
    public static class CurrencyFactory
    {
        public static Currency Create(string name, string code)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException(
                    CurrencyErrors.NameEmptyCode,
                    CurrencyErrors.NameEmptyMessage
                );

            if (string.IsNullOrWhiteSpace(code))
                throw new DomainException(
                    CurrencyErrors.CodeEmptyCode,
                    CurrencyErrors.CodeEmptyMessage
                );

            name = StringNormalizer.NormalizeName(name);

            if (name.Length > CurrencyRules.NameMaxLength)
            {
                throw new DomainException(
                    CurrencyErrors.NameTooLongCode,
                    CurrencyErrors.NameTooLongMessage(CurrencyRules.NameMaxLength)
                );
            }

            code = StringNormalizer.ToUpper(code);

            if (code.Length != CurrencyRules.IsoCodeLength)
                throw new DomainException(
                    CurrencyErrors.CodeInvalidLengthCode,
                    CurrencyErrors.CodeInvalidLengthMessage(CurrencyRules.IsoCodeLength)
                );
            return new Currency(name, code);
        }
    }
}
