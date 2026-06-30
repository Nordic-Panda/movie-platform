using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieService.API.Contracts;
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
public class MoviesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MoviesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMovieCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Id },
            ApiResponse<MovieDto>.Ok(result));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetMovieByIdQuery(id));

        return Ok(ApiResponse<MovieDto>.Ok(result));
    }

    [HttpGet]
    public async Task<IActionResult> GetMovies([FromQuery] GetMoviesQuery query)
    {
        var result = await _mediator.Send(new GetMoviesQuery());

        return Ok(ApiResponse<IReadOnlyList<MovieDto>>.Ok(result));
    }

    [HttpGet("details/{id:guid}")]
    public async Task<IActionResult> GetDetailsById([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetMovieDetailsByIdQuery(id));

        return Ok(ApiResponse<MovieDetailsDto>.Ok(result));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(ApiResponse<MovieDto>.Ok(result));
    }

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
    [FromBody] AddActorToMovieRequest request)
    {
        var command = MovieActorMapper.ToAddActorToMovieCommand(movieId, request.ActorId, request.CharacterName);
        var result = await _mediator.Send(command);
        return Ok(ApiResponse<MovieActorDto>.Ok(result));
    }
}