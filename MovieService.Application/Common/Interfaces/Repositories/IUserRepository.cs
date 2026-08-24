using MovieService.Domain.Users;

namespace MovieService.Application.Common.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetActiveUserByEmailAsync(string email);
        Task<User?> GetUserByIdAsync(Guid id);
        Task<User?> GetActiveUserByIdAsync(Guid id);
        Task<User?> GetUserByUsernameAsync(string name);

        Task<IReadOnlyList<User>> GetUsersByIdsAsync(IReadOnlyList<Guid> ids);
    }
}
