namespace MovieService.Domain.Languages
{
    public class Language
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Code { get; private set; } = string.Empty;
        public bool IsActive { get; private set; }

        private Language() { }

        internal Language(string name, string code)
        {
            Id = new Guid();
            Name = name;
            Code = code;
            IsActive = true;
        }

        public void Disable() => IsActive = false;

        public void Enable() => IsActive = true;
    }
}
