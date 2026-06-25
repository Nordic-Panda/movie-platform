using Microsoft.AspNetCore.Mvc;
using MovieService.Application.Movies.CreateMovie;
using MovieService.Application.Common.DTOs;

namespace MovieService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly CreateMovieHandler _createMovieHandler;

    public MoviesController(CreateMovieHandler createMovieHandler)
    {
        _createMovieHandler = createMovieHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMovieRequest request)
    {
        var result = await _createMovieHandler.AddMovie(request);

        // custom standardized response later with CreatedAtAction
        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Id },
            result
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        // placeholder
        return Ok();
    }
}