namespace MovieService.Domain.ValueObjects
{
    public class MovieDetails
    {
        public string Language { get; }
        public string? Synopsis { get; }
        public Money? Budget { get; }

        public MovieDetails(string language, string synopsis, Money? budget = null)
        {

            if (string.IsNullOrWhiteSpace(language))
                throw new ArgumentException("Language is required");

            Language = language;
            Synopsis = synopsis;
            Budget = budget;
        }

    }
}
