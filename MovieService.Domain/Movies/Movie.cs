using MovieService.Domain.Common.Enums;
using MovieService.Domain.Entities;
using MovieService.Domain.Reviews;
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

        //// DDD style, AddReview, AddMovieActor, as they all depend on Movie
        //public ICollection<Entities.MovieActor> MovieActors { get; private set; } = new List<Entities.MovieActor>();

        //public ICollection<Review> Reviews { get; private set; } = new List<Review>();

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