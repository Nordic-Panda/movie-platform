using MovieService.Domain.Roles;

namespace MovieService.Application.Common.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user, Role role);
    }
}
