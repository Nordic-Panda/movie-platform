using MovieService.Domain.Exceptions;

namespace MovieService.Domain.Currency
{
    public class Currency
    {
        public string Code { get; private set; } = null!;
        public string Name { get; private set; } = null!;
        public int NumberOfDecimal { get; private set; }
        public bool IsActive { get; private set; }

        // This is for EF Core to produce the object, it needs a paramless Constructor
        private Currency() { }

        public Currency(string code, string name, int numberOfDecimal)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new DomainException(
                    CurrencyErrors.CurrencyCodeEmptyCode,
                    CurrencyErrors.CurrencyCodeEmptyMessage);

            if (code.Trim().Length != CurrencyRules.IsoCodeLength)
                throw new DomainException(
                    CurrencyErrors.CurrencyCodeInvalidLengthCode,
                    CurrencyErrors.CurrencyCodeInvalidLengthMessage);

            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException(
                    CurrencyErrors.CurrencyNameEmptyCode,
                    CurrencyErrors.CurrencyNameEmptyMessage);

            if (numberOfDecimal < CurrencyRules.MinDecimal)
                throw new DomainException(
                    CurrencyErrors.CurrencyDecimalInvalidCode,
                    CurrencyErrors.CurrencyDecimalInvalidMessage);

            if (numberOfDecimal > CurrencyRules.MaxDecimal)
                throw new DomainException(
                    CurrencyErrors.CurrencyNameEmptyCode,
                    CurrencyErrors.CurrencyNameEmptyMessage);


            Code = code.Trim().ToUpper();
            Name = name.Trim();
            NumberOfDecimal = numberOfDecimal;
            IsActive = true;
        }

        public void Disable() => IsActive = false;
        public void Enable() => IsActive = true;
    }
}