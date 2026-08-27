using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Movies;
using MovieService.Domain.Reviews;
using MovieService.Domain.Users;

namespace MovieService.Application.Reviews.CreateReview
{
    public class CreateReviewHandler : IRequestHandler<CreateReviewCommand, ReviewDto>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _currentUser;

        public CreateReviewHandler(
            IReviewRepository reviewRepository,
            IMovieRepository movieRepository,
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            ICurrentUser currentUser
        )
        {
            _reviewRepository = reviewRepository;
            _movieRepository = movieRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _currentUser = currentUser;
        }

        public async Task<ReviewDto> Handle(
            CreateReviewCommand request,
            CancellationToken cancellationToken
        )
        {
            var existingMovie = await _movieRepository.GetActiveMovieByIdAsync(request.MovieId);

            if (existingMovie is null)
                throw new NotFoundException(
                    MovieErrors.MovieNotFoundCode,
                    MovieErrors.MovieNotFoundMessage
                );

            // TEMP SOLUTION, in reality we do not trust userID from request, but rather from authentication
            //var currentUserId = request.UserId;

            // Validation is in UserId's get, with custom response
            var currentUserId = _currentUser.UserId;

            var review = ReviewFactory.Create(
                request.MovieId,
                currentUserId,
                request.Comment,
                request.Rating
            );

            await _reviewRepository.AddReviewAsync(review);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var existingUser = await _userRepository.GetActiveUserByIdAsync(currentUserId);

            if (existingUser is null)
                throw new NotFoundException(UserErrors.NotFoundCode, UserErrors.NotFoundMessage);

            return ReviewMapper.ToDto(review, existingUser);
        }
    }
}
