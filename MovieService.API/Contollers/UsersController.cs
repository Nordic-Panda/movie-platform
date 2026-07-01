using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieService.Application.Users.login;

namespace MovieService.API.Contollers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] LoginCommand request)
        //{

        //}
    }
}
