using MovieService.Infrastructure.Data;

namespace MovieService.API.Common.Extensions
{
    public static class DbSeedExtensions
    {
        public static async Task SeedDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var db = scope.ServiceProvider
                .GetRequiredService<AppDbContext>();

            await UserSeeder.SeedUser(db);
            await GenreSeeder.SeedGenres(db);
            await MovieSeeder.SeedMovies(db);
        }
    }
}
