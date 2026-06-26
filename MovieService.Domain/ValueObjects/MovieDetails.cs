using MovieService.Domain.Exceptions;
using MovieService.Domain.Movies;

namespace MovieService.Domain.ValueObjects
{
    public class MovieDetails
    {
        public string Language { get; }
        public string? Synopsis { get; }
        public Money? Budget { get; }
        private MovieDetails(){ }

        public MovieDetails(string language, string? synopsis = null, Money? budget = null)
        {

            if (string.IsNullOrWhiteSpace(language))
                throw new DomainException(
                    MovieErrors.LanguageInvalidCode,
                    MovieErrors.LanguageInvalidMessage);

            Language = language;
            Synopsis = synopsis;
            Budget = budget;
        }

    }
}
