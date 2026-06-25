using MovieService.Domain.Exceptions;
using MovieService.Domain.Movies;

namespace MovieService.Domain.ValueObjects
{
    public class MovieDetails
    {
        public string Language { get; }
        public string? Synopsis { get; }
        public MovieService.Domain.Money.Money? Budget { get; }

        public MovieDetails(string language, string? synopsis = null, MovieService.Domain.Money.Money? budget = null)
        {

            if (string.IsNullOrWhiteSpace(language))
                throw new DomainException(
                    MovieErrors.MovieLanguageInvalidCode,
                    MovieErrors.MovieLanguageInvalidMessage);

            Language = language;
            Synopsis = synopsis;
            Budget = budget;
        }

    }
}
