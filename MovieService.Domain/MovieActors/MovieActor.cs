namespace MovieService.Domain.MovieActors
{
    public class MovieActor
    {
        public Guid MovieId { get; private set; }
        public Guid ActorId { get; private set; }
        public string CharacterName { get; private set; } = string.Empty;

        private MovieActor() { }

        internal MovieActor(Guid movieId, Guid actorId, string characterName)
        {
            MovieId = movieId;
            ActorId = actorId;
            CharacterName = characterName;
        }
    }
}
