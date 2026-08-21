using Microsoft.EntityFrameworkCore;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Domain.Roles;
using MovieService.Infrastructure.Data;

namespace MovieService.Infrastructure.Persistence.Roles
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<IReadOnlyList<Role>> GetAllActiveRolesAsync()
        {
            return await _context.Roles.Where(r => r.IsActive).ToListAsync();
        }

        public async Task<Role?> GetRoleByIdAsync(Guid id)
        {
            // here await is not really needed, as FirstOrDefaultAsync already returns a task
            // added to clarify
            return await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Role?> GetActiveRoleByIdAsync(Guid id)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Id == id && r.IsActive);
        }
    }
}
