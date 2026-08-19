using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieService.API.Common.Contracts;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Reviews.CreateReview;
using MovieService.Application.Reviews.GetReviewById;
using MovieService.Application.Reviews.GetReviewsByMovieId;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieService.API.Contollers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("movies/{movieId:guid}")]
        public async Task<IActionResult> GetReviewsByMovieId(Guid movieId)
        {
            var reviewList = await _mediator.Send(new GetReviewsByMovieIdQuery(movieId));

            return Ok(ApiResponse<IReadOnlyList<ReviewDto>>.Ok(reviewList));
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var reviewDto = await _mediator.Send(new GetReviewByIdQuery(id));

            return Ok(ApiResponse<ReviewDto>.Ok(reviewDto));
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
