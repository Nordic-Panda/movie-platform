using MovieService.Domain.Exceptions;

namespace MovieService.Domain.Actors
{
    public class Actor
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int BirthYear { get; private set; }

        private Actor() { }

        internal Actor(Guid id, string fName, string lName, int birthYear)
        {
            Id = id;
            FirstName = fName;
            LastName = lName;
            BirthYear = birthYear;
        }
    }
}