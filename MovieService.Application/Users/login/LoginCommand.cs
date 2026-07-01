using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Users.login
{
    public record LoginCommand
    (
        string Email,
        string Password
    ) : IRequest<LoginResponseDto>;
}
