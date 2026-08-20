using MovieService.Domain.Common.Normalizers;
using MovieService.Domain.Genres;
using MovieService.Domain.Languages;
using MovieService.Domain.ValueObjects;

namespace MovieService.Domain.Movies
{
    public class Movie
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public int Year { get; private set; }
        public TimeSpan Duration { get; private set; }

        public string? PosterUrl { get; private set; }

        // Strict DDD should not include this, aggregate should not own an other aggregate just to navigate
        private readonly List<Genre> _genres = new();
        public IReadOnlyCollection<Genre> Genres => _genres;

        public MovieDetail Details { get; private set; } = null!;

        // Strict DDD should not include this, aggregate should not own an other aggregate just to navigate
        public Language Language { get; private set; } = null!;

        public bool IsActive { get; private set; }

        public void Disable() => IsActive = false;

        public void Enable() => IsActive = true;

        private Movie() { }

        internal Movie(
            string title,
            int year,
            TimeSpan duration,
            IEnumerable<Genre> genres,
            MovieDetail details,
            Language language,
            string? posterUrl
        )
        {
            Id = Guid.NewGuid();
            Title = title;
            Year = year;
            Duration = duration;
            UpdateGenres(genres);
            Details = details;
            Language = language;
            PosterUrl = posterUrl;
            IsActive = true;
        }

        public void Update(
            string title,
            int year,
            TimeSpan duration,
            IEnumerable<Genre> genres,
            MovieDetail details,
            Language language,
            string? posterUrl
        )
        {
            MovieRules.ValidateTitle(title);

            var normalizedTitle = StringNormalizer.NormalizeTitle(title);

            MovieRules.ValidateTitleLength(normalizedTitle);
            MovieRules.ValidatePublishYear(year);
            MovieRules.ValidateDuration(duration);

            Title = normalizedTitle;
            Year = year;
            Duration = duration;
            UpdateGenres(genres);
            Details = details;
            Language = language;
            PosterUrl = posterUrl;
        }

        public void UpdateGenres(IEnumerable<Genre> genres)
        {
            _genres.Clear();
            _genres.AddRange(genres);
        }
    }
}
