namespace MovieService.Application.Common.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetActiveUserByEmailAsync(string email);
        Task<User?> GetUserByIdAsync(Guid id);
        Task<User?> GetActiveUserByIdAsync(Guid id);

        Task<IReadOnlyList<User>> GetUsersByIdsAsync(IReadOnlyList<Guid> ids);
    }
}
