using MovieService.Domain.Enums;

public class Movie
{
    public Guid Id { get; private set; }

    public string Title { get; private set; }
    public TimeSpan Duration { get; private set; }
    public Genre Genre { get; private set; }

    private readonly List<Review> _reviews = [];
    public IReadOnlyCollection<Review> Reviews => _reviews;

    private Movie() { }


    internal Movie(Guid id, string title, TimeSpan duration, Genre genre)
    {
        Id = Id;
        Title = title;
        Duration = duration;
        Genre = genre;
    }

    public void AddReview(string reviewerName, string comment, int rating)
    {
        var review = Review.Create(
            Id,
            reviewerName,
            comment,
            rating);

        _reviews.Add(review);
    }

    //public Movie(string title, TimeSpan duration, Genre genre)
    //{
    //    if (string.IsNullOrWhiteSpace(title))
    //        throw new DomainException(
    //            MovieErrors.MovieTitleEmptyCode,
    //            MovieErrors.MovieTitleEmptyMessage
    //            );

    //    if (duration <= TimeSpan.Zero)
    //        throw new DomainException(
    //            MovieErrors.MovieDurationInvalidCode,
    //            MovieErrors.MovieDurationInvalidMessage
    //            );

    //    if (!Enum.IsDefined(typeof(Genre), genre))
    //        throw new DomainException(
    //            MovieErrors.MovieGenreInvalidCode,
    //            MovieErrors.MovieGenreInvalidMessage
    //            );

    //    Title = title;
    //    Duration = duration;
    //    Genre = genre;
    //}

    //public void AddReview(string reviewerName, string comment, int rating)
    //{
    //    var review = new Review(
    //        Id,
    //        reviewerName,
    //        comment,
    //        rating);

    //    _reviews.Add(review);
    //}

}