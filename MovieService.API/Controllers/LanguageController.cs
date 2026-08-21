using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieService.API.Common.Contracts;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Languages.CreateLanguage;
using MovieService.Application.Languages.GetLanguageById;
using MovieService.Application.Languages.GetLanguages;
using MovieService.Domain.Languages;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLanguageById([FromRoute] Guid id)
        {
            var language = await _mediator.Send(new GetLanguageByIdQuery(id));

            return Ok(ApiResponse<LanguageDto>.Ok(language));
        }

        [HttpPost]
        public async Task<IActionResult> CreateLanguage([FromBody] CreateLanguageCommand command)
        {
            var language = await _mediator.Send(command);
            return CreatedAtAction(
                nameof(GetLanguageById),
                new { id = language.Id },
                ApiResponse<LanguageDto>.Ok(language)
            );
        }
    }
}
