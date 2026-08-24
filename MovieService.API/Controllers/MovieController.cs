using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieService.API.Common.Contracts;
using MovieService.API.Common.Policy;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Mappers;
using MovieService.Application.Movies.AddActorToMovie;
using MovieService.Application.Movies.CreateMovie;
using MovieService.Application.Movies.DeleteMovieById;
using MovieService.Application.Movies.GetMovieById;
using MovieService.Application.Movies.GetMovieDetailsById;
using MovieService.Application.Movies.GetMovies;
using MovieService.Application.Movies.UpdateMovie;

namespace MovieService.Api.Controllers;

[ApiController]
[Route("api/movies")]
public class MovieController : ControllerBase
{
    private readonly IMediator _mediator;

    public MovieController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //[Authorize(Policy = Policies.MovieCreate)]
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMovieCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Id },
            ApiResponse<MovieDto>.Ok(result)
        );
    }

    // Endspoints without attribute with Authorize are anonymous by default
    // However, if there is a global Authentication, then this is needed
    // Or add just for clarity reason
    [AllowAnonymous]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetMovieByIdQuery(id));

        return Ok(ApiResponse<MovieDto>.Ok(result));
    }

    [HttpGet]
    public async Task<IActionResult> GetMovies([FromQuery] GetMoviesQuery query)
    {
        var result = await _mediator.Send(query);

        return Ok(ApiResponse<PagedResult<MovieDto>>.Ok(result));
    }

    [HttpGet("{id:guid}/details")]
    public async Task<IActionResult> GetDetailsById([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetMovieDetailsByIdQuery(id));

        return Ok(ApiResponse<MovieDetailsDto>.Ok(result));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateMovie(
        [FromRoute] Guid id,
        [FromBody] UpdateMovieCommand command
    )
    {
        // Command is a record, so using 'with' here to create a copy with the route ID instead of modifying command.Id.
        var commandWithId = command with
        {
            Id = id,
        };

        var result = await _mediator.Send(commandWithId);

        return Ok(ApiResponse<MovieDto>.Ok(result));
    }

    // Must fullfill BOTH policy, not OR
    //[Authorize(Policy = Policies.MovieDelete)]
    //[Authorize(Policy = Policies.AdminOnly)]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteMovie([FromRoute] Guid id)
    {
        await _mediator.Send(new DeleteMovieCommand(id));

        // This breaks REST a little bit, should have been NoContent, but held response consistancy
        return Ok(ApiResponse<string>.Ok("Deleted"));
    }

    [HttpPost("{movieId:guid}/actors")]
    public async Task<IActionResult> AddActorToMovie(
        [FromRoute] Guid movieId,
        [FromBody] AddActorToMovieRequest request
    )
    {
        var command = MovieActorMapper.ToAddActorToMovieCommand(
            movieId,
            request.ActorId,
            request.CharacterName,
            request.IsMainCast
        );
        var result = await _mediator.Send(command);
        return Ok(ApiResponse<MovieActorDto>.Ok(result));
    }
}
