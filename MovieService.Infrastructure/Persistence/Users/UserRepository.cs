using Microsoft.EntityFrameworkCore;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Infrastructure.Data;

namespace MovieService.Infrastructure.Persistence.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetActiveUserByEmailAsync(string email)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(u =>
                u.Email == email && u.IsActive
            );
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetActiveUserByIdAsync(Guid id)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == id && u.IsActive);
        }

        public async Task<IReadOnlyList<User>> GetUsersByIdsAsync(IReadOnlyList<Guid> ids)
        {
            return await _appDbContext
                .Users.Where(u => ids.Contains(u.Id))
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
