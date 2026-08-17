using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieService.API.Common.Contracts;
using MovieService.API.Common.Policy;
using MovieService.Application.Actors.GetActors;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Genres.CreateGenre;
using MovieService.Application.Genres.GetGenreById;
using MovieService.Application.Movies.GetMovieById;

namespace MovieService.API.Contollers
{
    [Route("api/genres")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = Policies.AdminOnly)]
        [HttpPost]
        public async Task<IActionResult> Create(CreateGenreCommand command)
        {
            var genreDto = await _mediator.Send(command);
            return CreatedAtAction(
                nameof(GetById),
                new { id = genreDto.Id },
                ApiResponse<GenreDto>.Ok(genreDto));
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new GetGenreByIdQuery(id));

            return Ok(ApiResponse<GenreDto>.Ok(result));
        }
    }
}
