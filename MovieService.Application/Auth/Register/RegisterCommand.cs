using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Auth.Register
{
    public record RegisterCommand(
        string Provider,
        string? Email,
        string? Username,
        string? DisplayName,
        string? Password
    ) : IRequest<UserDto>;
}
