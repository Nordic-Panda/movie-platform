using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Interfaces.Repositories;

namespace MovieService.Application.Reviews.CreateReview
{
    public class CreateReviewHandler : IRequestHandler<CreateReviewCommand, ReviewDto>
    {
        private readonly IReviewRepository _reviewRepository;

        public CreateReviewHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<ReviewDto> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            //var review = ReviewFac
            //await _reviewRepository.AddReviewAsync();
            //await _reviewRepository.SaveChangesAsync();
            throw new NotImplementedException();
        }
    }
}
