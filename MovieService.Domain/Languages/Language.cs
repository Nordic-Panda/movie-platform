using MovieService.Domain.Common.Normalizers;

namespace MovieService.Domain.Languages
{
    public class Language
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Code { get; private set; } = string.Empty;
        public bool IsActive { get; private set; }

        public void Disable() => IsActive = false;

        public void Enable() => IsActive = true;

        private Language() { }

        internal Language(string name, string code)
        {
            Id = Guid.NewGuid();
            Name = name;
            Code = code;
            IsActive = true;
        }

        public void Update(string name, string code)
        {
            LanguageRules.ValidateName(name);
            LanguageRules.ValidateISOCode(code);

            var normalizedName = StringNormalizer.ToTitleCase(name);
            LanguageRules.ValidateNameLength(normalizedName);

            var normalizedCode = StringNormalizer.ToUpper(code);
            LanguageRules.ValidateISOCode(normalizedCode);

            Name = normalizedName;
            Code = normalizedCode;
        }
    }
}
