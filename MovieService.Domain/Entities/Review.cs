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

    public Review(string reviewerName, string comment, int rating)
    {
        if (rating < ReviewConstants.MinRating || rating > ReviewConstants.MaxRating)
            throw new DomainException(
                ReviewErrors.ReviewInvalidRatingCode,
                ReviewErrors.ReviewInvalidRatingMessage);

        ReviewerName = reviewerName;
        Comment = comment;
        Rating = rating;
    }
}