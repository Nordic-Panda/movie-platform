using MovieService.Domain.Common.Normalizers;

namespace MovieService.Domain.MovieActors
{
    public static class MovieActorFactory
    {
        public static MovieActor Create(Guid movieId, Guid actorId, string characterName)
        {
            MovieActorRules.ValidateGuid(movieId, actorId);
            MovieActorRules.ValidateName(characterName);

            var normalizedCharacterName = StringNormalizer.NormalizeName(characterName);

            return new MovieActor(movieId, actorId, normalizedCharacterName);
        }
    }
}
