using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Reviews;
using MovieService.Domain.Users;

namespace MovieService.Application.Reviews.GetReviewById
{
    public class GetReviewByIdHandler : IRequestHandler<GetReviewByIdQuery, ReviewDto>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IUserRepository _userRepository;

        public GetReviewByIdHandler(
            IReviewRepository reviewRepository,
            IUserRepository userRepository
        )
        {
            _reviewRepository = reviewRepository;
            _userRepository = userRepository;
        }

        public async Task<ReviewDto> Handle(
            GetReviewByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var existingReview = await _reviewRepository.GetActiveReviewById(request.Id);

            if (existingReview is null)
                throw new NotFoundException(
                    ReviewErrors.ReviewNotFoundCode,
                    ReviewErrors.ReviewNotFoundMessage
                );

            var existingUser = await _userRepository.GetUserByIdAsync(existingReview.UserId);

            if (existingUser is null)
                throw new NotFoundException(UserErrors.NotFoundCode, UserErrors.NotFoundMessage);

            return ReviewMapper.ToDto(existingReview, existingUser);
        }
    }
}
