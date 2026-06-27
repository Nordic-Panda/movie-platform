using MovieService.Domain.Enums;
using MovieService.Domain.Exceptions;
using MovieService.Domain.ValueObjects;

namespace MovieService.Domain.Movies
{
    public class Movie
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public TimeSpan Duration { get; private set; }
        public Genre Genre { get; private set; }
        public MovieDetails Details { get; private set; }

        private Movie() { }

        // no validation here because factory did it
        internal Movie(Guid id, string title, TimeSpan duration, Genre genre, MovieDetails details)
        {
            Id = id;
            Title = title;
            Duration = duration;
            Genre = genre;
            Details = details;
        }

        public void Update(string title, TimeSpan duration, Genre genre, MovieDetails details)
        { 
            Title = title;
            Duration = duration;
            Genre = genre;
            Details = details;
        }
    }
}