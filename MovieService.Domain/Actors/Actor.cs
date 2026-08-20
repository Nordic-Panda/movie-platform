namespace MovieService.Domain.Actors
{
    public class Actor
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int BirthYear { get; private set; }

        private Actor() { }

        internal Actor(string fName, string lName, int birthYear)
        {
            Id = Guid.NewGuid();
            FirstName = fName;
            LastName = lName;
            BirthYear = birthYear;
        }

        public void Update(string fName, string lName, int birthYear)
        {
            FirstName = fName;
            LastName = lName;
            BirthYear = birthYear;
        }
    }
}
