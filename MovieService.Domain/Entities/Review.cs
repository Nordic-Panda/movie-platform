using MovieService.Domain.Constants;
using MovieService.Domain.Exceptions;

public class Review
{
    public Guid Id { get; private set; }

    public string ReviewerName { get; private set; }
    public string Comment { get; private set; }
    public int Rating { get; private set; }

    public Guid MovieId { get; private set; }
    public Movie Movie { get; private set; }

    private Review() { }

    private Review(Guid id, Guid movieId, string reviewerName, string comment, int rating)
    {
        if (rating < ReviewConstants.MinRating ||
            rating > ReviewConstants.MaxRating)
        {
            throw new DomainException(
                ReviewErrors.ReviewInvalidRatingCode,
                ReviewErrors.ReviewInvalidRatingMessage);
        }

        Id = id;
        MovieId = movieId;
        ReviewerName = reviewerName;
        Comment = comment;
        Rating = rating;
    }

    public static Review Create(Guid movieId, string reviewerName, string comment, int rating)
    {
        return new Review(
            Guid.NewGuid(),
            movieId,
            reviewerName,
            comment,
            rating);
    }


    //public Review(
    //    Guid movieId,
    //    string reviewerName,
    //    string comment,
    //    int rating)
    //{
    //    if (rating < ReviewConstants.MinRating ||
    //        rating > ReviewConstants.MaxRating)
    //    {
    //        throw new DomainException(
    //            ReviewErrors.ReviewInvalidRatingCode,
    //            ReviewErrors.ReviewInvalidRatingMessage);
    //    }

    //    Id = Guid.NewGuid();
    //    MovieId = movieId;
    //    ReviewerName = reviewerName;
    //    Comment = comment;
    //    Rating = rating;
    //}
}