using MovieService.Domain.Common.Normalizers;

namespace MovieService.Domain.Currencies
{
    public static class CurrencyFactory
    {
        public static Currency Create(string name, string code)
        {
            CurrencyRules.ValidateName(name);
            CurrencyRules.ValidateCode(code);

            var normalizedName = StringNormalizer.NormalizeName(name);
            var normalizedCode = StringNormalizer.ToUpper(code);

            CurrencyRules.ValidateLength(normalizedName, normalizedCode);

            return new Currency(normalizedName, normalizedCode);
        }
    }
}
