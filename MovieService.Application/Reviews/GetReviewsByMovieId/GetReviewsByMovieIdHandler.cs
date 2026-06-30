using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Movies;

namespace MovieService.Application.Reviews.GetReviewsByMovieId
{
    public class GetReviewsByMovieIdHandler : IRequestHandler<GetReviewsByMovieIdQuery, IReadOnlyList<ReviewDto>>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMovieRepository _movieRepository;

        public GetReviewsByMovieIdHandler(IReviewRepository reviewRepository, IMovieRepository movieRepository)
        {
            _reviewRepository = reviewRepository;
            _movieRepository = movieRepository;
        }

        public async Task<IReadOnlyList<ReviewDto>> Handle(GetReviewsByMovieIdQuery request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetByIdAsync(request.MovieId);

            if (movie == null)
                throw new NotFoundException(MovieErrors.MovieNotFoundCode, MovieErrors.MovieNotFoundMessage);

            var reviews = await _reviewRepository.GetReviewsByMovieId(request.MovieId);

            return reviews
                .Select(ReviewMapper.ToDto)
                .ToList()
                .AsReadOnly();
        }
    }
}
