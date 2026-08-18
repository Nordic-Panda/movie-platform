namespace MovieService.Domain.ValueObjects
{
    public class MovieDetail
    {
        public string Language { get; } = string.Empty;
        public string? Synopsis { get; }
        public Money? Budget { get; }

        private MovieDetail() { }

        internal MovieDetail(string language, string? synopsis = null, Money? budget = null)
        {
            Language = language;
            Synopsis = synopsis;
            Budget = budget;
        }
    }
}
