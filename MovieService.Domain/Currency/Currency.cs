using MovieService.Domain.Common.Exceptions;

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
                    CurrencyErrors.CodeEmptyCode,
                    CurrencyErrors.CodeEmptyMessage);

            if (code.Trim().Length != CurrencyRules.IsoCodeLength)
                throw new DomainException(
                    CurrencyErrors.CodeInvalidLengthCode,
                    CurrencyErrors.CodeInvalidLengthMessage(CurrencyRules.IsoCodeLength));

            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException(
                    CurrencyErrors.NameEmptyCode,
                    CurrencyErrors.NameEmptyMessage);

            if (numberOfDecimal < CurrencyRules.MinDecimal)
                throw new DomainException(
                    CurrencyErrors.DecimalTooSmallCode,
                    CurrencyErrors.DecimalTooSmallMessage(CurrencyRules.MinDecimal));

            if (numberOfDecimal > CurrencyRules.MaxDecimal)
                throw new DomainException(
                    CurrencyErrors.DecimalTooBigCode,
                    CurrencyErrors.DecimalTooBigMessage(CurrencyRules.MaxDecimal));


            Code = code.Trim().ToUpper();
            Name = name.Trim();
            NumberOfDecimal = numberOfDecimal;
            IsActive = true;
        }

        public void Disable() => IsActive = false;
        public void Enable() => IsActive = true;
    }
}