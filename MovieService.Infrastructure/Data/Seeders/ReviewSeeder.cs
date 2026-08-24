using Microsoft.EntityFrameworkCore;
using MovieService.Domain.Reviews;

namespace MovieService.Infrastructure.Data.Seeders
{
    public static class ReviewSeeder
    {
        private static readonly Guid MovieId = Guid.Parse("91501865-A7E1-43D0-AE5D-13AAC4043ACC");

        public static async Task SeedReviews(AppDbContext db)
        {
            if (await db.Reviews.AnyAsync())
                return;

            var yang = await db.Users.FirstAsync(u => u.Email == "y@user.com");

            var test = await db.Users.FirstAsync(u => u.Email == "test@movie.com");

            var inactiveUser = await db.Users.FirstAsync(u => u.Email == "inactive@movie.com");

            inactiveUser.Disable();

            db.Reviews.AddRange(
                ReviewFactory.Create(
                    MovieId,
                    yang.Id,
                    "A beautiful and surprisingly touching film. Ove is such a memorable character.",
                    5
                ),
                ReviewFactory.Create(
                    MovieId,
                    yang.Id,
                    "En väldigt fin film med mycket humor och värme. Jag tyckte verkligen om den.",
                    5
                ),
                ReviewFactory.Create(
                    MovieId,
                    test.Id,
                    "Funny, emotional and very well acted. Definitely worth watching.",
                    4
                ),
                ReviewFactory.Create(
                    MovieId,
                    test.Id,
                    "En sorglig men samtidigt varm berättelse. Musiken och skådespelet passar perfekt.",
                    4
                ),
                ReviewFactory.Create(
                    MovieId,
                    inactiveUser.Id,
                    "En fantastisk film. Ove är både rolig, envis och väldigt mänsklig.",
                    5
                )
            );

            await db.SaveChangesAsync();
        }
    }
}
