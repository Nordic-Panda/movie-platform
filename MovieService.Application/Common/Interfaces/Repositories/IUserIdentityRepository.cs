using MovieService.Domain.UserIdentities;

namespace MovieService.Application.Common.Interfaces.Repositories
{
    public interface IUserIdentityRepository
    {
        Task<UserIdentity?> GetByProviderAndSubjectAsync(string provider, string subject);

        Task<IReadOnlyList<UserIdentity>> GetByUserIdAsync(Guid userId);

        Task AddAsync(UserIdentity userIdentity);
    }
}
