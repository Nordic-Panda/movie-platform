using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Users.Login
{
    public record LoginCommand
    (
        string Email,
        string Password
    ) : IRequest<LoginResponseDto>;
}
