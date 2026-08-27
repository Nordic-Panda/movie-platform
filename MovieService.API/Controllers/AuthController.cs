using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieService.API.Common.Contracts;
using MovieService.Application.Auth.Login;
using MovieService.Application.Auth.Register;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Mappers;

namespace MovieService.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginCommand command,
            CancellationToken cancellationToken
        )
        {
            var result = await _mediator.Send(command, cancellationToken);

            if (!string.IsNullOrWhiteSpace(result.AccessToken))
            {
                Response.Cookies.Append(
                    "access_token",
                    result.AccessToken,
                    new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.None,
                        MaxAge = TimeSpan.FromMinutes(result.ExpiresInMinutes ?? 60),
                        Path = "/",
                    }
                );
            }

            var response = LoginResponseMapper.ToDto(result);

            return Ok(ApiResponse<LoginResponseDto>.Ok(response));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(
            [FromBody] RegisterCommand command,
            CancellationToken cancellationToken
        )
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse<UserDto>.Ok(result));
        }
    }
}
