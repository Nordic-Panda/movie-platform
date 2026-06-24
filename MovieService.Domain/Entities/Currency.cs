namespace MovieService.Domain.Entities
{
    public class Currency
    {
        public string Code { get; private set; } = null!;
        public string Name { get; private set; } = null!;
        public int NumberOfDecimal { get; private set; } = 2;
        public bool IsActive { get; private set; } = true;

        // This is for EF Core to produce the object, it needs a paramless Constructor
        private Currency() { }

        public Currency(string code, string name, int numberOfDecimal)
        {
            Code = code.ToUpper();
            Name = name;
            NumberOfDecimal = numberOfDecimal;
            IsActive = true;
        }

        public void Disable() => IsActive = false;
        public void Enable() => IsActive = true;
    }
}