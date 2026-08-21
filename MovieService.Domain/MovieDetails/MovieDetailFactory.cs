using MovieService.Domain.Common.Normalizers;
using MovieService.Domain.ValueObjects;

namespace MovieService.Domain.MovieDetails
{
    public class MovieDetailFactory
    {
        public static MovieDetail Create(string? synopsis, Money? budget)
        {
            synopsis = string.IsNullOrWhiteSpace(synopsis)
                ? synopsis
                : StringNormalizer.NormalizeDescription(synopsis);

            return new MovieDetail(synopsis, budget);
        }
    }
}
