using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieService.API.Common.Contracts;
using MovieService.API.Common.Policy;
using MovieService.Application.Actors.CreateActor;
using MovieService.Application.Actors.GetActorById;
using MovieService.Application.Actors.GetActors;
using MovieService.Application.Actors.UpdateActor;
using MovieService.Application.Common.DTOs;

namespace MovieService.API.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ActorController(IMediator mediator)
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
                ApiResponse<ActorDto>.Ok(actorDto)
            );
        }

        [Authorize(Policy = Policies.AdminOnly)]
        [HttpPut]
        public async Task<IActionResult> Put(UpdateActorCommand command)
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
