using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Reviews.GetReviewsByMovieId
{
    public record GetReviewsByMovieIdQuery
    (
        Guid MovieId
    ) : IRequest<IReadOnlyList<ReviewDto>>;
}
