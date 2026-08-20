using MovieService.Infrastructure.Data;
using MovieService.Infrastructure.Data.Seeders;

namespace MovieService.API.Common.Extensions
{
    public static class DbSeedExtensions
    {
        public static async Task SeedDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            await CurrencySeeder.SeedCurrencies(db);
            await UserSeeder.SeedUser(db);
            await LanguageSeeder.SeedLanguages(db);
            await GenreSeeder.SeedGenres(db);
            await MovieSeeder.SeedMovies(db);
        }
    }
}
