using Microsoft.EntityFrameworkCore;
using MovieService.Domain.MovieActors;
using MovieService.Infrastructure.Data;

namespace MovieService.Infrastructure.Data.Seeders
{
    public static class MovieActorSeeder
    {
        public static async Task SeedMovieActors(AppDbContext db)
        {
            if (await db.MovieActor.AnyAsync())
                return;

            var movieId = Guid.Parse("91501865-A7E1-43D0-AE5D-13AAC4043ACC");

            var movie = await db.Movies.FirstAsync(m => m.Id == movieId);

            var actors = await db.Actors.ToDictionaryAsync(a => $"{a.FirstName} {a.LastName}");

            var movieActors = new[]
            {
                MovieActorFactory.Create(movie.Id, actors["Rolf Lassgård"].Id, "Ove", true),
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
