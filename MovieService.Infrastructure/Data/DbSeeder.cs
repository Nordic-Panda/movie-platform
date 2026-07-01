using MovieService.Domain.Users;

namespace MovieService.Infrastructure.Data
{
    public class DbSeeder
    {
        public static async Task SeedUser(AppDbContext db)
        {
            if (db.Users.Any())
                return;

            db.Users.Add(new User(Guid.NewGuid(), "test@user.com", "password"));

            await db.SaveChangesAsync();
        }
    }
}
