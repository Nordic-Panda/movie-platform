using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieService.API.Contracts;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Movies.CreateMovie;

namespace MovieService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    //private readonly CreateMovieHandler _createMovieHandler;

    //public MoviesController(CreateMovieHandler createMovieHandler)
    //{
    //    _createMovieHandler = createMovieHandler;
    //}

    //[HttpPost]
    //public async Task<IActionResult> Create(CreateMovieRequest request)
    //{
    //    var result = await _createMovieHandler.AddMovie(request);

    //    return CreatedAtAction(
    //        nameof(GetById),
    //        new { id = result.Id },
    //        ApiResponse<MovieDto>.Ok(result)
    //    );
    //}

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
    public IActionResult GetById(Guid id)
    {
        // placeholder
        return Ok();
    }
}