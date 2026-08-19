using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieService.API.Common.Contracts;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Languages.GetLanguages;

namespace MovieService.API.Controllers
{
    [Route("api/languages")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LanguageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetLanguages()
        {
            var languages = await _mediator.Send(new GetLanguagesQuery());
            return Ok(ApiResponse<IReadOnlyList<LanguageDto>>.Ok(languages));
        }
    }
}
