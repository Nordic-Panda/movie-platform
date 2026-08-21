using MovieService.Domain.Common.Normalizers;

namespace MovieService.Domain.Genres
{
    public class Genre
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public bool IsActive { get; private set; }

        public void Disable() => IsActive = false;

        public void Enable() => IsActive = true;

        private Genre() { }

        internal Genre(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            IsActive = true;
        }

        public void Update(string name)
        {
            GenreRules.ValidateName(name);
            var normalizedName = StringNormalizer.NormalizeName(name);
            GenreRules.ValidateLength(normalizedName);

            Name = normalizedName;
        }
    }
}
