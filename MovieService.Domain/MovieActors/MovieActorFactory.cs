using MovieService.Domain.Common.Exceptions;
using MovieService.Domain.Common.Normalizers;

namespace MovieService.Domain.MovieActors
{
    public static class MovieActorFactory
    {
        public static MovieActor Create(Guid movieId, Guid actorId, string characterName)
        {
            if (movieId == Guid.Empty)
                throw new DomainException(
                    MovieActorErrors.MovieIdEmptyCode,
                    MovieActorErrors.MovieIdEmptyMessage
                );

            if (actorId == Guid.Empty)
                throw new DomainException(
                    MovieActorErrors.ActorIdEmptyCode,
                    MovieActorErrors.ActorIdEmptyMessage
                );

            if (string.IsNullOrWhiteSpace(characterName))
                throw new DomainException(
                    MovieActorErrors.CharacterNameEmptyCode,
                    MovieActorErrors.CharacterNameEmptyMessage
                );

            var normalizedCharacterName = StringNormalizer.NormalizeName(characterName);

            return new MovieActor(movieId, actorId, normalizedCharacterName);
        }
    }
}
