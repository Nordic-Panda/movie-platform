using MovieService.Domain.Movies;

namespace MovieService.Application.Movies.GetMovies.Filters
{
    public static class MovieDurationFilter
    {
        public static IQueryable<Movie> ApplyDurationFilter(
            this IQueryable<Movie> query,
            int? duration) 
        {
            if (!duration.HasValue)
                return query;

            var durationTimeSpan = TimeSpan.FromMinutes(duration.Value);

            return query.Where(m => m.Duration == durationTimeSpan);
        }
    }
}
