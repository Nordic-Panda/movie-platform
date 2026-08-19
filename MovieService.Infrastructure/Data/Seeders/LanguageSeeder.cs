using Microsoft.EntityFrameworkCore;
using MovieService.Domain.Languages;
using MovieService.Infrastructure.Data.SeedData;

namespace MovieService.Infrastructure.Data.Seeders
{
    public class LanguageSeeder
    {
        public static async Task SeedLanguages(AppDbContext db)
        {
            if (await db.Languages.AnyAsync())
                return;
            var languages = new[]
            {
                LanguageFactory.Create(LanguageSeedData.EnglishName, LanguageSeedData.EnglishCode),
                LanguageFactory.Create(LanguageSeedData.ChineseName, LanguageSeedData.ChineseCode),
                LanguageFactory.Create(LanguageSeedData.SwedishName, LanguageSeedData.SwedishCode),
                LanguageFactory.Create(LanguageSeedData.DanishName, LanguageSeedData.DanishCode),
                LanguageFactory.Create(
                    LanguageSeedData.JapaneseName,
                    LanguageSeedData.JapaneseCode
                ),
            };
            db.Languages.AddRange(languages);
            await db.SaveChangesAsync();
        }
    }
}
