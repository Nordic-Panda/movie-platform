using MovieService.Domain.Exceptions;
using MovieService.Domain.MovieActor;

namespace MovieService.Domain.Entities
{
    public class MovieActor
    {
        public Guid MovieId { get; private set; }
        public Guid ActorId { get; private set; }

        public string CharacterName { get; private set; }

        private MovieActor() { }

        public MovieActor(Guid movieId, Guid actorId, string characterName)
        {
            if (movieId == Guid.Empty)
                throw new DomainException(
                    MovieActorErrors.MovieIdEmptyCode,
                    MovieActorErrors.MovieIdEmptyMessage);

            if (actorId == Guid.Empty)
                throw new DomainException(
                    MovieActorErrors.ActorIdEmptyCode,
                    MovieActorErrors.ActorIdEmptyMessage);

            if (string.IsNullOrWhiteSpace(characterName))
                throw new DomainException(
                    MovieActorErrors.CharacterNameEmptyCode,
                    MovieActorErrors.CharacterNameEmptyMessage);

            MovieId = movieId;
            ActorId = actorId;
            CharacterName = characterName.Trim();
        }
    }
}