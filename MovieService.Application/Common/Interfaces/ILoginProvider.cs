using MovieService.Application.Auth.Login;
using MovieService.Domain.Users;

namespace MovieService.Application.Common.Interfaces
{
    public interface ILoginProvider
    {
        string Provider { get; }

        Task<User> AuthenticateAsync(LoginCommand command, CancellationToken cancellationToken);
    }
}
