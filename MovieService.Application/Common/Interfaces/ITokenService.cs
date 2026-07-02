using MovieService.Domain.Users;
namespace MovieService.Application.Common.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
