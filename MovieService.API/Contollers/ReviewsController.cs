using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MovieService.API.Contracts;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Reviews.CreateReview;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieService.API.Contollers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //// GET: api/<ReviewsController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<ReviewsController>/5
        [HttpGet("{id}")]
        public string GetById(int id)
        {
            return "value";
        }

        [HttpPost("movies/{movieId:guid}")]
        public async Task<IActionResult> AddReviewToMovie(Guid movieId, CreateReviewRequest request)
        {
            var reviewDto = await _mediator.Send(new CreateReviewCommand(movieId, request.Comment, request.Rating));

            return CreatedAtAction(
                nameof(GetById),
                new { id = reviewDto.Id },
                ApiResponse<ReviewDto>.Ok(reviewDto));

        }

        //// PUT api/<ReviewsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ReviewsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
