using MovieService.Domain.Genres;
using MovieService.Domain.ValueObjects;

namespace MovieService.Domain.Movies
{
    public class Movie
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public TimeSpan Duration { get; private set; }

        // DDD style, we don't expose the collection, If it needs to be changed, go through MY domain behavior
        private readonly List<Genre> _genres = new();
        public IReadOnlyCollection<Genre> Genres => _genres;
        public MovieDetails Details { get; private set; } = null!;

        //// DDD style, AddReview, AddMovieActor, as they all depend on Movie
        //public ICollection<Entities.MovieActor> MovieActors { get; private set; } = new List<Entities.MovieActor>();

        //public ICollection<Review> Reviews { get; private set; } = new List<Review>();

        private Movie() { }

        // no validation here because factory did it
        internal Movie(Guid id, string title, TimeSpan duration, IEnumerable<Genre> genres, MovieDetails details)
        {
            Id = id;
            Title = title;
            Duration = duration;
            UpdateGenres(genres);
            Details = details;
        }

        public void Update(string title, TimeSpan duration, IEnumerable<Genre> genres, MovieDetails details)
        { 
            Title = title;
            Duration = duration;
            UpdateGenres(genres);
            Details = details;
        }

        public void UpdateGenres(IEnumerable<Genre> genres)
        {
            _genres.Clear();
            _genres.AddRange(genres);
        }
    }
}