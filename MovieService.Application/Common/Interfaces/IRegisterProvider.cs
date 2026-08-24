using MovieService.Application.Auth.Register;
using MovieService.Domain.Users;

namespace MovieService.Application.Common.Interfaces
{
    public interface IRegisterProvider
    {
        string Provider { get; }

        Task<User> RegisterAsync(RegisterCommand command, CancellationToken cancellationToken);
    }
}
