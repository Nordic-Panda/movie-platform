using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Reviews.CreateReview
{
    public class CreateReviewHandler : IRequestHandler<CreateReviewCommand, ReviewDto>
    {

        public Task<ReviewDto> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
