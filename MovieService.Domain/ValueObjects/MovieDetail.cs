namespace MovieService.Domain.ValueObjects
{
    public class MovieDetail
    {
        public string? Synopsis { get; }
        public Money? Budget { get; }

        private MovieDetail() { }

        internal MovieDetail(string? synopsis = null, Money? budget = null)
        {
            Synopsis = synopsis;
            Budget = budget;
        }
    }
}
