//using MediatR;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using MovieService.API.Common.Contracts;
//using MovieService.Application.Common.DTOs;
//using MovieService.Application.Users.Login;

//namespace MovieService.API.Contollers
//{
//    [Route("api/users")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly IMediator _mediator;

//        public UserController(IMediator mediator)
//        {
//            _mediator = mediator;
//        }

//        [AllowAnonymous]
//        [HttpPost("login")]
//        public async Task<IActionResult> Login([FromBody] LoginCommand request)
//        {
//            var responseDto = await _mediator.Send(request);

//            return Ok(ApiResponse<LoginResponseDto>.Ok(responseDto));
//        }
//    }
//}
