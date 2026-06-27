using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieService.API.Contracts;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Movies.CreateMovie;
using MovieService.Application.Movies.DeleteMovieById;
using MovieService.Application.Movies.GetAllMovies;
using MovieService.Application.Movies.GetMovieById;
using MovieService.Application.Movies.GetMovieDetailsById;
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
    public async Task<IActionResult> Create(CreateMovieCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Id },
            ApiResponse<MovieDto>.Ok(result));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetMovieByIdQuery(id));

        return Ok(ApiResponse<MovieDto>.Ok(result));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMovies()
    {
        var result = await _mediator.Send(new GetAllMoviesQuery());

        return Ok(ApiResponse<IReadOnlyList<MovieDto>>.Ok(result));
    }

    [HttpGet("details/{id:guid}")]
    public async Task<IActionResult> GetDetailsById(Guid id)
    {
        var result = await _mediator.Send(new GetMovieDetailsByIdQuery(id));

        return Ok(ApiResponse<MovieDetailsDto>.Ok(result));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMovie(UpdateMovieCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(ApiResponse<MovieDto>.Ok(result));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteMovie(Guid id)
    {
        await _mediator.Send(new DeleteMovieCommand(id));

        // This breaks REST a little bit, should have been NoContent, but held response consistancy
        return Ok(ApiResponse<string>.Ok("Deleted"));
    }
}