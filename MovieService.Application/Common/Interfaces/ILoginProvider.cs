using MovieService.Application.Auth.Login;

namespace MovieService.Application.Common.Interfaces
{
    public interface ILoginProvider
    {
        string Provider { get; }

        // Used to return User, BUT since external login for the first time does not have user
        // So we use a nullable result
        Task<LoginProviderResult> AuthenticateAsync(
            LoginCommand command,
            CancellationToken cancellationToken
        );
    }
}
