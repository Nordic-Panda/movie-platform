using Microsoft.EntityFrameworkCore;
using MovieService.Domain.Reviews;

namespace MovieService.Infrastructure.Data.Seeders
{
    public static class ReviewSeeder
    {
        public static async Task SeedReviews(AppDbContext db)
        {
            if (await db.Reviews.AnyAsync())
                return;

            var yang = await db.Users.FirstAsync(u => u.Email == "y@user.com");

            var test = await db.Users.FirstAsync(u => u.Email == "test@movie.com");

            var inactiveUser = await db.Users.FirstAsync(u => u.Email == "inactive@movie.com");
            inactiveUser.Disable();

            var movie = await db.Movies.FirstAsync(m =>
                m.Title == "A Man Called Ove"
                && m.Year == 2015
                && m.Duration == TimeSpan.FromMinutes(116)
                && m.IsActive
            );

            db.Reviews.AddRange(
                ReviewFactory.Create(
                    movie.Id,
                    yang.Id,
                    "I really enjoyed *A Man Called Ove*. At first, Ove comes across as an extremely grumpy and difficult old man who seems to dislike almost everyone around him. However, as the story develops, you slowly understand why he has become the way he is. The characters are surprisingly warm and funny, and the story manages to balance humor with some genuinely emotional moments.\r\n\r\nWhat I liked most was how Ove gradually changes through his relationships with the people around him. It is a simple story, but it has a lot to say about loneliness, friendship, love, and finding a reason to keep going. Some parts were predictable, but I still found myself caring about the characters and wanting to see how everything turned out.\r\n\r\nOverall, I would definitely recommend this book. It is funny, touching, and easy to get into, with a main character who becomes much more lovable than you might expect at first.",
                    5
                ),
                ReviewFactory.Create(
                    movie.Id,
                    yang.Id,
                    "En väldigt fin film med mycket humor och värme. Jag tyckte verkligen om den.",
                    5
                ),
                ReviewFactory.Create(
                    movie.Id,
                    test.Id,
                    "Funny, emotional and very well acted. Definitely worth watching.",
                    4
                ),
                ReviewFactory.Create(
                    movie.Id,
                    test.Id,
                    "En sorglig men samtidigt varm berättelse. Musiken och skådespelet passar perfekt.",
                    4
                ),
                ReviewFactory.Create(
                    movie.Id,
                    inactiveUser.Id,
                    "En fantastisk film. Ove är både rolig, envis och väldigt mänsklig.",
                    5
                )
            );

            await db.SaveChangesAsync();
        }
    }
}
