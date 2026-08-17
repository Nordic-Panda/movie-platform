using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Movies;
using MovieService.Domain.Reviews;

namespace MovieService.Application.Reviews.CreateReview
{
    public class CreateReviewHandler : IRequestHandler<CreateReviewCommand, ReviewDto>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateReviewHandler(IReviewRepository reviewRepository, IMovieRepository movieRepository, IUnitOfWork unitOfWork)
        {
            _reviewRepository = reviewRepository;
            _movieRepository = movieRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ReviewDto> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetByIdAsync(request.MovieId);

            if (movie == null)
                throw new NotFoundException(MovieErrors.MovieNotFoundCode, MovieErrors.MovieNotFoundMessage);


            var review = ReviewFactory.Create(request.MovieId, request.Comment, request.Rating);

            await _reviewRepository.AddReviewAsync(review);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return ReviewMapper.ToDto(review);
        }
    }
}
