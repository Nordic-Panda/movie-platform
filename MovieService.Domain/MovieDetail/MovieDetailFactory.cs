using MovieService.Domain.Common.Exceptions;
using MovieService.Domain.Movies;
using MovieService.Domain.ValueObjects;

namespace MovieService.Domain.Movie.Details
{
    public class MovieDetailFactory
    {
        public static MovieDetail Create(
            string language,
            string? synopsis = null,
            ValueObjects.Money? budget = null
        )
        {
            if (string.IsNullOrWhiteSpace(language))
                throw new DomainException(
                    MovieErrors.LanguageInvalidCode,
                    MovieErrors.LanguageInvalidMessage
                );

            return new MovieDetail(language.ToUpper(), synopsis, budget);
        }
    }
}
