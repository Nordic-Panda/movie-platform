using MovieService.Domain.Users;

namespace MovieService.Infrastructure.Data
{
    public class DbSeeder
    {
        public static async Task SeedUser(AppDbContext db)
        {
            if (db.Users.Any())
                return;

            var password = "pass";
            var hashedPass = BCrypt.Net.BCrypt.HashPassword(password);
            db.Users.Add(new User(Guid.NewGuid(), "test@user.com", hashedPass, Domain.Common.Enums.UserRole.User));
            db.Users.Add(new User(Guid.NewGuid(), "test@admin.com", hashedPass, Domain.Common.Enums.UserRole.Admin));
            await db.SaveChangesAsync();
        }
    }
}
