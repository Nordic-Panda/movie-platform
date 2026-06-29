using MovieService.Domain.Exceptions;

namespace MovieService.Domain.MovieActor
{
    public static class MovieActorFactory
    {
        public static Entities.MovieActor Create(Guid movieId, Guid actorId, string characterName) {

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

            return new Entities.MovieActor(
                    Guid.NewGuid(),
                    movieId,
                    actorId,
                    characterName.Trim()
                );
        }
    }
}
