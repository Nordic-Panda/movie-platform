using Microsoft.EntityFrameworkCore;
using MovieService.Domain.Roles;
using MovieService.Infrastructure.Data.SeedData;

namespace MovieService.Infrastructure.Data.Seeders
{
    public class RoleSeeder
    {
        public static async Task SeedRoles(AppDbContext db)
        {
            if (await db.Roles.AnyAsync())
                return;

            var roles = new[]
            {
                RoleFactory.Create(RoleSeedData.AdminName, RoleSeedData.AdminCode),
                RoleFactory.Create(RoleSeedData.UserName, RoleSeedData.UserCode),
            };

            db.Roles.AddRange(roles);

            await db.SaveChangesAsync();
        }
    }
}
