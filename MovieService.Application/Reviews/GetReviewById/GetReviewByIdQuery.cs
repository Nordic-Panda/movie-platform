using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Reviews.GetReviewById
{
    public record GetReviewByIdQuery
    (
        Guid Id
    ) : IRequest<ReviewDto>;
}
