using MovieService.Domain.Auth;

namespace MovieService.Application.Common.Interfaces
{
    public interface IExternalRegistrationTokenService
    {
        string CreateToken(ExternalIdentity identity);

        ExternalIdentity ValidateToken(string token);
    }
}
