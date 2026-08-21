using MovieService.Domain.Common.Normalizers;

namespace MovieService.Domain.Actors
{
    public class Actor
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int BirthYear { get; private set; }

        public bool IsActive { get; private set; }

        public void Disable() => IsActive = false;

        public void Enable() => IsActive = true;

        private Actor() { }

        internal Actor(string fName, string lName, int birthYear)
        {
            Id = Guid.NewGuid();
            FirstName = fName;
            LastName = lName;
            BirthYear = birthYear;
            IsActive = true;
        }

        public void Update(string fName, string lName, int birthYear)
        {
            ActorRules.ValidateName(fName, lName);
            ActorRules.ValidateBirthYear(birthYear);

            var normalizedFirstName = StringNormalizer.NormalizeName(fName);
            var normalizedLastName = StringNormalizer.NormalizeName(lName);

            FirstName = normalizedFirstName;
            LastName = normalizedLastName;
            BirthYear = birthYear;
        }
    }
}
