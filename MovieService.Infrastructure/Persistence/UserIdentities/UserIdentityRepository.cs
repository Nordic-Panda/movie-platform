using Microsoft.EntityFrameworkCore;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Domain.UserIdentities;
using MovieService.Infrastructure.Data;

namespace MovieService.Infrastructure.Persistence.UserIdentities
{
    public class UserIdentityRepository : IUserIdentityRepository
    {
        private readonly AppDbContext _context;

        public UserIdentityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserIdentity?> GetByProviderAndSubjectAsync(
            string provider,
            string subject
        )
        {
            return await _context.UserIdentities.FirstOrDefaultAsync(x =>
                x.Provider == provider && x.Subject == subject
            );
        }

        public async Task<IReadOnlyList<UserIdentity>> GetByUserIdAsync(Guid userId)
        {
            return await _context.UserIdentities.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task AddAsync(UserIdentity userIdentity)
        {
            await _context.UserIdentities.AddAsync(userIdentity);
        }
    }
}
