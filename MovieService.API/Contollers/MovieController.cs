using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieService.API.Contracts;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Movies.CreateMovie;
using MovieService.Application.Movies.GetMovieById;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MovieService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
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
}