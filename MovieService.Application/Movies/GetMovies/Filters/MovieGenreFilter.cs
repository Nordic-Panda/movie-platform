using MovieService.Domain.Movies;

namespace MovieService.Application.Movies.GetMovies.Filters
{
    // Feature-based filters
    public static class MovieGenreFilter
    {
        public static IQueryable<Movie> ApplyGenreFilter(
            this IQueryable<Movie> query,
            ICollection<Guid>? genreIds)
        {

            // Do nothing if genre is null or whitespace
            if (genreIds == null || genreIds.Count == 0)
                return query;

            // Filter movies that have one of the specified genres
            return query.Where(movie =>
                movie.Genres.Any(genre =>
                    genreIds.Contains(genre.Id)));

            // IF movies must match ALL specified genres:
            //return query.Where(movie =>
            //    genreIds.All(id =>
            //        movie.Genres.Any(genre => genre.Id == id)));

            // No longer using enum for Genre, below is for self note for educational purposes. 

            //// Throw custom exception if genre is not in Enum
            //if (!Enum.TryParse<Genre>(genre, true, out var parsed))
            //{
            //    throw new ValidationException(new Dictionary<string, string[]>
            //    {
            //        {
            //            "Genre",
            //            new[] { $"Invalid genre: {genre}" }
            //        }
            //    });
            //}

            //// Here it hides what is invalid by failling all condition.
            //// Could also throw exception, it's less forgiving but tells user what input is wrong
            //// ?genre=NotRealGenre is not a No Movies Found, but rather a Invalid Input
            ////if (!Enum.TryParse<Genre>(genre, true, out var parsed))
            ////    return query.Where(m => false);


            //// Filter
            //return query.Where(m => m.Genre == parsed);
        }
    }
}
