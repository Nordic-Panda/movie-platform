using MovieService.Domain.Genres;
using MovieService.Domain.ValueObjects;

namespace MovieService.Domain.Movies
{
    public class Movie
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public int Year { get; private set; }
        public TimeSpan Duration { get; private set; }

        private readonly List<Genre> _genres = new();
        public IReadOnlyCollection<Genre> Genres => _genres;

        public MovieDetail Details { get; private set; } = null!;

        private Movie() { }

        internal Movie(
            Guid id,
            string title,
            int year,
            TimeSpan duration,
            IEnumerable<Genre> genres,
            MovieDetail details
        )
        {
            Id = id;
            Title = title;
            Year = year;
            Duration = duration;
            UpdateGenres(genres);
            Details = details;
        }

        public void Update(
            string title,
            int year,
            TimeSpan duration,
            IEnumerable<Genre> genres,
            MovieDetail details
        )
        {
            Title = title;
            Year = year;
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
