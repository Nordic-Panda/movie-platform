namespace MovieService.Domain.MovieActors
{
    public class MovieActor
    {
        public Guid Id { get; private set; }
        public Guid MovieId { get; private set; }
        public Guid ActorId { get; private set; }
        public string CharacterName { get; private set; } = string.Empty;
        public bool IsMainCast { get; private set; }

        private MovieActor() { }

        internal MovieActor(Guid movieId, Guid actorId, string characterName, bool isMainCast)
        {
            Id = Guid.NewGuid();
            MovieId = movieId;
            ActorId = actorId;
            CharacterName = characterName;
            IsMainCast = isMainCast;
        }
    }
}
