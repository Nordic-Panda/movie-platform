using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Reviews.CreateReview
{
    public record CreateReviewCommand(Guid MovieId, string Comment, int Rating)
        : IRequest<ReviewDto>;
}
