using MovieService.Domain.Common.Normalizers;

namespace MovieService.Domain.Actors
{
    public class ActorFactory
    {
        public static Actor Create(string fName, string lName, int birthYear)
        {
            ActorRules.ValidateName(fName, lName);
            ActorRules.ValidateBirthYear(birthYear);

            var normalizedFirstName = StringNormalizer.NormalizeName(fName);
            var normalizedLastName = StringNormalizer.NormalizeName(lName);

            return new Actor(normalizedFirstName, normalizedLastName, birthYear);
        }
    }
}
