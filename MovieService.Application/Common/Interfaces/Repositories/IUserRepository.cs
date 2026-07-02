using MovieService.Domain.Users;

namespace MovieService.Application.Common.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
    }
}
