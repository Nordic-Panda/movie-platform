using MovieService.Domain.Exceptions;

namespace MovieService.Domain.Actors
{
    public class Actor
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int BirthYear { get; private set; }

        private Actor() { }

        public Actor(string name, int birthYear)
        {

            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException(
                    ActorErrors.ActorNameEmptyCode,
                    ActorErrors.ActorNameEmptyMessage);

            if (birthYear < ActorRules.EarliestYear || birthYear > DateTime.UtcNow.Year)
                throw new DomainException(
                    ActorErrors.ActorBirthYearInvalidCode,
                    ActorErrors.ActorBirthYearInvalidMessage);
            
            Id = Guid.NewGuid();
            Name = name;
            BirthYear = birthYear;
        }
    }
}





//namespace MovieService.Domain.Entities
//{
//    public class Actor
//    {
//        public Guid Id { get; private set; }

//        public string Name { get; private set; }
//        public int BirthYear { get; private set; }

//        private readonly List<MovieActor> _movies = [];
//        public IReadOnlyCollection<MovieActor> Movies => _movies;

//        private Actor() { }

//        public Actor(string name, int birthYear)
//        {
//            Id = Guid.NewGuid();
//            Name = name;
//            BirthYear = birthYear;
//        }

//        public void AddMovie(Movie movie, string characterName)
//        {
//            var link = new MovieActor(movie, this, characterName);
//            _movies.Add(link);
//        }
//    }
//}