using MovieService.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace MovieService.Infrastructure.Data
{
    public class UserSeeder
    {
        public static async Task SeedUser(AppDbContext db)
        {
            if (await db.Users.AnyAsync())
                return;

            var password = "pass";
            var hashedPass = BCrypt.Net.BCrypt.HashPassword(password);
            db.Users.Add(new User(Guid.NewGuid(), "test@user.com", hashedPass, Domain.Common.Enums.UserRole.User));
            db.Users.Add(new User(Guid.NewGuid(), "test@admin.com", hashedPass, Domain.Common.Enums.UserRole.Admin));
            await db.SaveChangesAsync();
        }
    }
}
