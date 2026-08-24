using MovieService.Domain.Common.Normalizers;

namespace MovieService.Domain.MovieActors
{
    public static class MovieActorFactory
    {
        public static MovieActor Create(
            Guid movieId,
            Guid actorId,
            string characterName,
            bool isMainCast
        )
        {
            MovieActorRules.ValidateGuid(movieId, actorId);
            MovieActorRules.ValidateName(characterName);

            var normalizedCharacterName = StringNormalizer.NormalizeName(characterName);

            return new MovieActor(movieId, actorId, normalizedCharacterName, isMainCast);
        }
    }
}
