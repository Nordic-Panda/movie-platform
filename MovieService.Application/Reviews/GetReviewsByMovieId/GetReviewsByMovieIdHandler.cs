using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Movies;

namespace MovieService.Application.Reviews.GetReviewsByMovieId
{
    public class GetReviewsByMovieIdHandler
        : IRequestHandler<GetReviewsByMovieIdQuery, IReadOnlyList<ReviewDto>>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IUserRepository _userRepository;

        public GetReviewsByMovieIdHandler(
            IReviewRepository reviewRepository,
            IMovieRepository movieRepository,
            IUserRepository userRepository
        )
        {
            _reviewRepository = reviewRepository;
            _movieRepository = movieRepository;
            _userRepository = userRepository;
        }

        public async Task<IReadOnlyList<ReviewDto>> Handle(
            GetReviewsByMovieIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var existingMovie = await _movieRepository.GetActiveMovieByIdAsync(request.MovieId);

            if (existingMovie is null)
                throw new NotFoundException(
                    MovieErrors.MovieNotFoundCode,
                    MovieErrors.MovieNotFoundMessage
                );

            var reviews = await _reviewRepository.GetActiveReviewsByMovieId(request.MovieId);

            var userIds = reviews.Select(x => x.UserId).Distinct().ToList();

            var users = userIds.Count == 0 ? [] : await _userRepository.GetUsersByIdsAsync(userIds);

            var result = reviews
                .Join(
                    users,
                    review => review.UserId,
                    user => user.Id,
                    (review, user) =>
                        new ReviewDto(
                            review.Id,
                            review.MovieId,
                            review.UserId,
                            user.Username,
                            user.DisplayName,
                            review.Comment,
                            review.Rating
                        )
                )
                .ToList()
                .AsReadOnly();

            //return reviews.Select(ReviewMapper.ToDto).ToList().AsReadOnly();
            return result;
        }
    }
}
