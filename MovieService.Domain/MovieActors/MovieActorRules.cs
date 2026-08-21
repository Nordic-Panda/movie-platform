using MovieService.Domain.Common.Exceptions;

namespace MovieService.Domain.MovieActors
{
    public static class MovieActorRules
    {
        public static void ValidateGuid(Guid movieId, Guid actorId)
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
        }

        public static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException(
                    MovieActorErrors.CharacterNameEmptyCode,
                    MovieActorErrors.CharacterNameEmptyMessage
                );
        }
    }
}
