using MovieService.Domain.Auth;

namespace MovieService.Application.Common.Interfaces
{
    public interface IExternalAuthenticationProvider
    {
        string Provider { get; }

        Task<ExternalIdentity> AuthenticateAsync(
            string credential,
            CancellationToken cancellationToken
        );
    }
}
