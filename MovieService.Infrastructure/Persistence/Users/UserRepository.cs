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
            return await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User?> GetActiveUserByEmailAsync(string email)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(x =>
                x.Email == email && x.IsActive
            );
        }
    }
}
