using MediatR;

namespace MovieService.Application.Auth.Login
{
    // External providers do not rely on an identifier provided by the client.
    // Different authentication providers requires different credentials, thus if external, identifier and password is null

    // Credential could be token, could be authorization code etc

    // Basically: Local? Identifier + password
    // External? Credential
    public record LoginCommand(
        string Provider,
        string? Identifier,
        string? Password,
        string? Credential
    ) : IRequest<LoginResult>;
}
