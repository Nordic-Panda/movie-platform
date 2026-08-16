using MovieService.Domain.Genres;
using MovieService.Infrastructure.Data.SeedData;

namespace MovieService.Infrastructure.Data
{
    public class GenreSeeder
    {
        public static async Task SeedGenres(AppDbContext db)
        {
            if (db.Genres.Any())
                return;

            var genres = new[]
            {
                GenreFactory.Create(GenreSeedData.Action),
                GenreFactory.Create(GenreSeedData.Adventure),
                GenreFactory.Create(GenreSeedData.Animation),
                GenreFactory.Create(GenreSeedData.Comedy),
                GenreFactory.Create(GenreSeedData.Crime),
                GenreFactory.Create(GenreSeedData.Drama),
                GenreFactory.Create(GenreSeedData.Horror),
                GenreFactory.Create(GenreSeedData.Romance),
                GenreFactory.Create(GenreSeedData.ScienceFiction),
                GenreFactory.Create(GenreSeedData.Thriller)
            };

            db.Genres.AddRange(genres);

            await db.SaveChangesAsync();
        }
    }
}
