using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieService.API.Contracts;
using MovieService.Application.Actors.CreateActor;
using MovieService.Application.Actors.GetActorById;
using MovieService.Application.Actors.GetActors;
using MovieService.Application.Actors.PutActor;
using MovieService.Application.Common.DTOs;


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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allActors = await _mediator.Send(new GetActorsQuery());

            return Ok(ApiResponse<IReadOnlyList<ActorDto>>.Ok(allActors));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var actorDto = await _mediator.Send(new GetActorByIdQuery(id));
            return Ok(ApiResponse<ActorDto>.Ok(actorDto));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateActorCommand command)
        {
            var actorDto = await _mediator.Send(command);
            return CreatedAtAction(
                nameof(GetById),
                new { id = actorDto.Id },
                ApiResponse<ActorDto>.Ok(actorDto));
        }

        [HttpPut]
        public async Task<IActionResult> Put(PutActorCommand command)
        {
            var actorDto = await _mediator.Send(command);
            return Ok(ApiResponse<ActorDto>.Ok(actorDto));
        }

        //// DELETE api/<ActorsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
