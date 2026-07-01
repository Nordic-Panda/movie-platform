using Microsoft.EntityFrameworkCore;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Domain.Users;
using MovieService.Infrastructure.Data;

namespace MovieService.Infrastructure.Persistence.Users
{
    public class UsersRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UsersRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
