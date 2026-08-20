namespace MovieService.Domain.Actors
{
    public class ActorFactory
    {
        public static Actor Create(string fName, string lName, int birthYear)
        {
            ActorRules.ValidateName(fName, lName);
            ActorRules.ValidateBirthYear(birthYear);

            return new Actor(fName, lName, birthYear);
        }
    }
}
