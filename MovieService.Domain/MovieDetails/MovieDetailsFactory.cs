using MovieService.Domain.Exceptions;
using MovieService.Domain.Movies;
using MovieService.Domain.ValueObjects;

namespace MovieService.Domain.Movie.Details
{
    public class MovieDetailsFactory
    {
        public static MovieDetails Create(string language, string? synopsis = null, ValueObjects.Money? budget = null) 
        {
            if (string.IsNullOrWhiteSpace(language))
                throw new DomainException(
                    ActorErrors.LanguageInvalidCode,
                    ActorErrors.LanguageInvalidMessage);

            return new MovieDetails(language.ToUpper(), synopsis, budget);
        }
    }
}
