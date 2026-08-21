using Microsoft.EntityFrameworkCore;
using MovieService.Domain.Users;

namespace MovieService.Infrastructure.Data.Seeders
{
    public class UserSeeder
    {
        public static async Task SeedUser(AppDbContext db)
        {
            if (await db.Users.AnyAsync())
                return;

            var password = "pass";
            var hashedPass = BCrypt.Net.BCrypt.HashPassword(password);
            db.Users.Add(new User("test@user.com", hashedPass, Domain.Common.Enums.UserRole.User));
            db.Users.Add(
                new User("test@admin.com", hashedPass, Domain.Common.Enums.UserRole.Admin)
            );
            await db.SaveChangesAsync();
        }
    }
}
