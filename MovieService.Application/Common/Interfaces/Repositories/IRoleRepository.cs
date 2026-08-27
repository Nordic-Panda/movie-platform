using MovieService.Domain.Roles;

namespace MovieService.Application.Common.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Task<IReadOnlyList<Role>> GetAllRolesAsync();
        Task<IReadOnlyList<Role>> GetAllActiveRolesAsync();

        Task<Role?> GetRoleByIdAsync(Guid id);
        Task<Role?> GetActiveRoleByIdAsync(Guid id);

        Task<Role?> GetRoleByCodeAsync(string code);
        Task<Role?> GetDefaultRoleAsync();
    }
}
