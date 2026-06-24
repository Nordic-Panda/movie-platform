using MovieService.Domain.Enums;
using MovieService.Domain.Exceptions;

namespace MovieService.Domain.Movies
{
    public class Movie
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public TimeSpan Duration { get; private set; }
        public Genre Genre { get; private set; }

        private Movie() { }

        // no validation here because factory did it
        internal Movie(Guid id, string title, TimeSpan duration, Genre genre)
        {
            Id = id;
            Title = title;
            Duration = duration;
            Genre = genre;
        }
    }
}






// Below approach is making Movie be the main aggregate that holds everything, could be too big, making filtering, saving db harder, Thus, we split

//using MovieService.Domain.Entities;
//using MovieService.Domain.Enums;

//public class Movie
//{
//    public Guid Id { get; private set; }

//    public string Title { get; private set; }
//    public TimeSpan Duration { get; private set; }
//    public Genre Genre { get; private set; }

//    private readonly List<Review> _reviews = [];
//    public IReadOnlyCollection<Review> Reviews => _reviews;

//    private readonly List<MovieActor> _actors = [];
//    public IReadOnlyCollection<MovieActor> Actors => _actors;

//    private Movie() { }


//    internal Movie(Guid id, string title, TimeSpan duration, Genre genre)
//    {
//        Id = id;
//        Title = title;
//        Duration = duration;
//        Genre = genre;
//    }

//    public void AddReview(string reviewerName, string comment, int rating)
//    {
//        var review = Review.Create(
//            Id,
//            reviewerName,
//            comment,
//            rating);

//        _reviews.Add(review);
//    }

//    public void AddActor(Actor actor, string characterName)
//    {
//        if (_actors.Any(x => x.ActorId == actor.Id))
//            return;

//        var link = new MovieActor(this, actor, characterName);
//        _actors.Add(link);
//    }

//    //public Movie(string title, TimeSpan duration, Genre genre)
//    //{
//    //    if (string.IsNullOrWhiteSpace(title))
//    //        throw new DomainException(
//    //            MovieErrors.MovieTitleEmptyCode,
//    //            MovieErrors.MovieTitleEmptyMessage
//    //            );

//    //    if (duration <= TimeSpan.Zero)
//    //        throw new DomainException(
//    //            MovieErrors.MovieDurationInvalidCode,
//    //            MovieErrors.MovieDurationInvalidMessage
//    //            );

//    //    if (!Enum.IsDefined(typeof(Genre), genre))
//    //        throw new DomainException(
//    //            MovieErrors.MovieGenreInvalidCode,
//    //            MovieErrors.MovieGenreInvalidMessage
//    //            );

//    //    Title = title;
//    //    Duration = duration;
//    //    Genre = genre;
//    //}

//    //public void AddReview(string reviewerName, string comment, int rating)
//    //{
//    //    var review = new Review(
//    //        Id,
//    //        reviewerName,
//    //        comment,
//    //        rating);

//    //    _reviews.Add(review);
//    //}

//}