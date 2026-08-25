using MovieService.Domain.Auth;
using MovieService.Domain.Users;

namespace MovieService.Application.Auth.Login
{
    // This handles both local login which has User, and external that does not
    public record LoginProviderResult(User? User, ExternalIdentity? ExternalIdentity);
}
