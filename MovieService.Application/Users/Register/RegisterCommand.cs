using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Users.Register
{
    public record RegisterCommand(
        string Email,
        string Username,
        string DisplayName,
        string Password
    ) : IRequest<UserDto>;
}
