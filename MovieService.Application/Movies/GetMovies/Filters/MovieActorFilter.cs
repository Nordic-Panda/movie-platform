using MovieService.Domain.Actors;
using MovieService.Domain.Entities;
using MovieService.Domain.Movies;

namespace MovieService.Application.Movies.GetMovies.Filters
{
    public static class MovieActorFilter
    {
        public static IQueryable<Movie> ApplyActorFilter(
            this IQueryable<Movie> query,
            string? firstName,
            string? lastName,
            IQueryable<MovieActor> movieActors,
            IQueryable<Actor> actors)
        {
            if (string.IsNullOrWhiteSpace(firstName) &&
                string.IsNullOrWhiteSpace(lastName))
                return query;

            var actorQuery = actors;

            if (!string.IsNullOrWhiteSpace(firstName))
                actorQuery = actorQuery.Where(a => a.FirstName.Contains(firstName));

            if (!string.IsNullOrWhiteSpace(lastName))
                actorQuery = actorQuery.Where(a => a.LastName.Contains(lastName));

            var actorIds = actorQuery.Select(a => a.Id);

            return query.Where(m =>
                movieActors.Any(ma =>
                    ma.MovieId == m.Id &&
                    actorIds.Contains(ma.ActorId)));
        }
    }
}
