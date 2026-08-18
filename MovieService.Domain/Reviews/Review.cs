namespace MovieService.Domain.Reviews
{
    public class Review
    {
        public Guid Id { get; private set; }
        public Guid MovieId { get; private set; }

        public string Comment { get; private set; }
        public int Rating { get; private set; }

        private Review() { }

        public Review(Guid id, Guid movieId, string comment, int rating)
        {
            Id = id;
            MovieId = movieId;
            Comment = comment;
            Rating = rating;
        }
    }
}