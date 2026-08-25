using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Auth.Register
{
    public record CompleteExternalRegistrationCommand(string RegistrationToken, string Username)
        : IRequest<LoginResponseDto>;
}
