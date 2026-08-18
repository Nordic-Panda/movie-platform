using MovieService.Domain.Common.Exceptions;
using MovieService.Domain.Movies;
using MovieService.Domain.ValueObjects;

namespace MovieService.Domain.Movie.Details
{
    public class MovieDetailFactory
    {
        public static MovieDetail Create(string? synopsis = null, ValueObjects.Money? budget = null)
        {
            return new MovieDetail(synopsis, budget);
        }
    }
}
