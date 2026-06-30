using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Reviews;

namespace MovieService.Application.Reviews.GetReviewById
{
    public class GetReviewByIdHandler : IRequestHandler<GetReviewByIdQuery, ReviewDto>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewByIdHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<ReviewDto> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.GetReviewById(request.Id);

            if (review == null)
                throw new NotFoundException(ReviewErrors.ReviewNotFoundCode, ReviewErrors.ReviewNotFoundMessage);

            return ReviewMapper.ToDto(review);
        }
    }
}
