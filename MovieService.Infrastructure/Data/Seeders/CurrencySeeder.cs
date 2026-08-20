using Microsoft.EntityFrameworkCore;
using MovieService.Domain.Currencies;

namespace MovieService.Infrastructure.Data.Seeders
{
    public static class CurrencySeeder
    {
        public static async Task SeedCurrencies(AppDbContext db)
        {
            if (await db.Currencies.AnyAsync())
                return;

            var currencies = new[]
            {
                CurrencyFactory.Create("US Dollar", "USD"),
                CurrencyFactory.Create("Euro", "EUR"),
                CurrencyFactory.Create("Swedish Krona", "SEK"),
                CurrencyFactory.Create("Danish Krone", "DKK"),
                CurrencyFactory.Create("Chinese Yuan", "CNY"),
                CurrencyFactory.Create("Japanese Yen", "JPY"),
            };

            db.Currencies.AddRange(currencies);

            await db.SaveChangesAsync();
        }
    }
}
