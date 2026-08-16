using MovieService.Application.Common.Exceptions;
using MovieService.Domain.Genres;
using MovieService.Domain.Movies;

namespace MovieService.Application.Movies.GetMovies.Filters
{
    // Feature-based filters
    public static class MovieGenreFilter
    {
        public static IQueryable<Movie> ApplyGenreFilter(
            this IQueryable<Movie> query,
            string? genre)
        {
            
            // Do nothing if genre is null or whitespace
            if (string.IsNullOrWhiteSpace(genre))
                return query;


            // Throw custom exception if genre is not in Enum
            if (!Enum.TryParse<Genre>(genre, true, out var parsed))
            {
                throw new ValidationException(new Dictionary<string, string[]>
                {
                    {
                        "Genre",
                        new[] { $"Invalid genre: {genre}" }
                    }
                });
            }

            // Here it hides what is invalid by failling all condition.
            // Could also throw exception, it's less forgiving but tells user what input is wrong
            // ?genre=NotRealGenre is not a No Movies Found, but rather a Invalid Input
            //if (!Enum.TryParse<Genre>(genre, true, out var parsed))
            //    return query.Where(m => false);


            // Filter
            return query.Where(m => m.Genre == parsed);
        }
    }
}
