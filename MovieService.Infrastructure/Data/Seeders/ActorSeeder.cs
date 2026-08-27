using Microsoft.EntityFrameworkCore;
using MovieService.Domain.Actors;
using MovieService.Infrastructure.Data;

public static class ActorSeeder
{
    public static async Task SeedActors(AppDbContext db)
    {
        if (await db.Actors.AnyAsync())
            return;

        var inactiveActor = ActorFactory.Create("Inactive", "Test Actor", 1950);

        inactiveActor.Disable();

        var actors = new[]
        {
            ActorFactory.Create("Rolf", "Lassgård", 1955),
            ActorFactory.Create("Bahar", "Pars", 1979),
            ActorFactory.Create("Filip", "Berg", 1986),
            ActorFactory.Create("Ida", "Engvoll", 1985),
            ActorFactory.Create("Katarina", "Ewerlöf", 1959),
            inactiveActor,
        };

        db.Actors.AddRange(actors);

        await db.SaveChangesAsync();
    }
}
