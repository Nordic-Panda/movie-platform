using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Auth.Login
{
    public record LoginCommand(string Provider, string? Email, string? Password)
        : IRequest<LoginResponseDto>;
}
