namespace MovieService.Domain.Reviews
{
    public class Review
    {
        public Guid Id { get; private set; }

        public Guid MovieId { get; private set; }
        public Guid UserId { get; private set; }

        public string Comment { get; private set; }
        public int Rating { get; private set; }

        public bool IsActive { get; private set; }

        public void Hide() => IsActive = false;

        public void Restore() => IsActive = true;

        private Review() { }

        internal Review(Guid movieId, Guid userId, string comment, int rating)
        {
            Id = Guid.NewGuid();
            MovieId = movieId;
            UserId = userId;
            Comment = comment;
            Rating = rating;
            IsActive = true;
        }
    }
}
