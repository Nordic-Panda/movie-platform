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

            var inactiveUser = UserFactory.Create(
                "inactive@movie.com",
                "inactive",
                "Inactive Test User",
                hashedPassword,
                userRole.Id
            );

            inactiveUser.Disable();

            db.Users.AddRange(
                UserFactory.Create(
                    "y@admin.com",
                    "admin",
                    "I'm just an Admin",
                    hashedPassword,
                    adminRole.Id
                ),
                UserFactory.Create(
                    "y@user.com",
                    "yang",
                    "YangThePanda",
                    hashedPassword,
                    userRole.Id
                ),
                UserFactory.Create(
                    "test@movie.com",
                    "testUserName",
                    "Test account displayname - i'm just keep spamming since i need to be long desu",
                    hashedPassword,
                    userRole.Id
                ),
                inactiveUser
            );

            await db.SaveChangesAsync();
        }
    }
}
