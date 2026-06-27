namespace MovieService.Domain.ValueObjects
{
    public class MovieDetails
    {
        public string Language { get; }
        public string? Synopsis { get; }
        public Money? Budget { get; }
        private MovieDetails(){ }

        internal MovieDetails(string language, string? synopsis = null, Money? budget = null)
        {
            Language = language;
            Synopsis = synopsis;
            Budget = budget;
        }

    }
}
