using MovieService.Domain.Common.Exceptions;

namespace MovieService.Domain.Actors
{
    public static class ActorRules
    {
        public const int EarliestYear = 1850;

        public static void ValidateName(string fName, string lName)
        {
            if (string.IsNullOrWhiteSpace(fName))
                throw new DomainException(
                    ActorErrors.ActorFirstNameEmptyCode,
                    ActorErrors.ActorFirstNameEmptyMessage
                );

            if (string.IsNullOrWhiteSpace(lName))
                throw new DomainException(
                    ActorErrors.ActorLastNameEmptyCode,
                    ActorErrors.ActorLastNameEmptyMessage
                );
        }

        public static void ValidateBirthYear(int birthYear)
        {
            if (birthYear < EarliestYear || birthYear > DateTime.UtcNow.Year)
                throw new DomainException(
                    ActorErrors.ActorBirthYearInvalidCode,
                    ActorErrors.ActorBirthYearInvalidMessage(EarliestYear, DateTime.UtcNow.Year)
                );
        }
    }
}
