using MovieService.Domain.Movies;

namespace MovieService.Application.Movies.GetMovies.Filters
{
    public static class MovieTitleFilter
    {
        public static IQueryable<Movie> ApplyTitleFilter(
            this IQueryable<Movie> query,
            string? title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return query;

            return query.Where(m => m.Title.Contains(title));
        }
    }
}
