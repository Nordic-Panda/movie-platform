using MovieService.Domain.ValueObjects;

namespace MovieService.Domain.Movie.Details
{
    public class MovieDetailFactory
    {
        public static MovieDetail Create(string? synopsis, ValueObjects.Money? budget)
        {
            return new MovieDetail(synopsis, budget);
        }
    }
}
