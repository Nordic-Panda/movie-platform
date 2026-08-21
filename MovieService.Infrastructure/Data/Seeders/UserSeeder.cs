using Microsoft.EntityFrameworkCore;
using MovieService.Domain.Users;

namespace MovieService.Infrastructure.Data.Seeders
{
    public class UserSeeder
    {
        public static async Task SeedUsers(AppDbContext db)
        {
            if (await db.Users.AnyAsync())
                return;

            var userRole = await db.Roles.FirstAsync(r => r.Code == "USER");

            var adminRole = await db.Roles.FirstAsync(r => r.Code == "ADMIN");

            var password = "pass";
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            db.Users.AddRange(
                UserFactory.Create("y@admin.com", hashedPassword, adminRole.Id),
                UserFactory.Create("y@user.com", hashedPassword, userRole.Id)
            );
            await db.SaveChangesAsync();
        }
    }
}
