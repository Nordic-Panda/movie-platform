using Microsoft.EntityFrameworkCore;
using MovieService.Domain.MovieActors;

namespace MovieService.Infrastructure.Data.Seeders
{
    public static class MovieActorSeeder
    {
        public static async Task SeedMovieActors(AppDbContext db)
        {
            if (await db.MovieActor.AnyAsync())
                return;

            var movie = await db.Movies.FirstAsync(m =>
                m.Title == "A Man Called Ove"
                && m.Year == 2015
                && m.Duration == TimeSpan.FromMinutes(116)
                && m.IsActive
            );

            var actors = await db.Actors.ToDictionaryAsync(a => $"{a.FirstName} {a.LastName}");

            var movieActors = new[]
            {
                MovieActorFactory.Create(movie.Id, actors["Rolf Lassgård"].Id, "Ove", true),
                MovieActorFactory.Create(
                    movie.Id,
                    actors["Rolf Lassgård"].Id,
                    "Ove (Test case for same actor different character)",
                    true
                ),
                MovieActorFactory.Create(movie.Id, actors["Bahar Pars"].Id, "Parvaneh", true),
                MovieActorFactory.Create(movie.Id, actors["Filip Berg"].Id, "Young Ove", false),
                MovieActorFactory.Create(movie.Id, actors["Ida Engvoll"].Id, "Sonja", true),
                MovieActorFactory.Create(movie.Id, actors["Katarina Ewerlöf"].Id, "Anita", false),
            };

            db.MovieActor.AddRange(movieActors);

            await db.SaveChangesAsync();
        }
    }
}
