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
                userRole.Id
            );

            var admin = UserFactory.Create(
                "y@admin.com",
                "admin",
                "I'm just an Admin",
                adminRole.Id
            );

            var user = UserFactory.Create("y@user.com", "user", "YangThePanda", userRole.Id);

            var test = UserFactory.Create(
                "test@movie.com",
                "testUserName",
                "Test - I spam since i need to be long desu",
                userRole.Id
            );

            inactiveUser.Disable();

            var users = new[] { admin, user, test, inactiveUser };

            db.Users.AddRange(users);

            var identities = users
                .Select(user => UserIdentityFactory.CreateLocal(user.Id, hashedPassword))
                .ToArray();

            db.UserIdentities.AddRange(identities);

            await db.SaveChangesAsync();
        }
    }
}
