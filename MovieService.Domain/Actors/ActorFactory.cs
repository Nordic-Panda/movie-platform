using MovieService.Domain.Common.Exceptions;

namespace MovieService.Domain.Actors
{
    public class ActorFactory
    {
        public static Actor Create(string fName, string lName, int birthYear)
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

            if (birthYear < ActorRules.EarliestYear || birthYear > DateTime.UtcNow.Year)
                throw new DomainException(
                    ActorErrors.ActorBirthYearInvalidCode,
                    ActorErrors.ActorBirthYearInvalidMessage(
                        ActorRules.EarliestYear,
                        DateTime.UtcNow.Year
                    )
                );

            return new Actor(fName, lName, birthYear);
        }
    }
}
