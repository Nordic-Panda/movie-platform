using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieService.API.Contracts;
using MovieService.Application.Actors.CreateActor;
using MovieService.Application.Actors.GetActors;
using MovieService.Application.Common.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace MovieService.API.Contollers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ActorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ActorsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allActors = await _mediator.Send(new GetActorsQuery());

            return Ok(ApiResponse<IReadOnlyList<ActorDto>>.Ok(allActors));
        }

        // GET api/<ActorsController>/5
        [HttpGet("{id}")]
        public string GetById(int id)
        {
            return "value";
        }

        // POST api/<ActorsController>
        [HttpPost]
        public async Task<IActionResult> Create(CreateActorCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                ApiResponse<ActorDto>.Ok(result));
        }

        // PUT api/<ActorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ActorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
