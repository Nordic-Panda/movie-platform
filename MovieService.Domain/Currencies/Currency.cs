namespace MovieService.Domain.Currencies
{
    public class Currency
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string Code { get; private set; } = null!;
        public bool IsActive { get; private set; }

        // This is for EF Core to produce the object, it needs a paramless Constructor
        private Currency() { }

        internal Currency(string name, string code)
        {
            Id = Guid.NewGuid();
            Name = name;
            Code = code;
            IsActive = true;
        }

        public void Disable() => IsActive = false;

        public void Enable() => IsActive = true;
    }
}
