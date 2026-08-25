using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Auth.Login
{
    public record LoginCommand(
        string Provider,
        string? Identifier,
        string? Password,
        string? Credential
    ) : IRequest<LoginResponseDto>;
}
