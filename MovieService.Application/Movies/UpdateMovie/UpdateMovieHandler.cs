using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Genres;
using MovieService.Domain.Money;
using MovieService.Domain.Movie.Details;
using MovieService.Domain.Movies;
using MovieService.Domain.ValueObjects;

namespace MovieService.Application.Movies.UpdateMovie
{
    public class UpdateMovieHandler : IRequestHandler<UpdateMovieCommand, MovieDto>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMovieHandler(IMovieRepository movieRepository, IGenreRepository genreRepository, IUnitOfWork unitOfWork)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<MovieDto> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetByIdAsync(request.Id);

            if (movie == null)
                throw new NotFoundException(MovieErrors.MovieNotFoundCode, MovieErrors.MovieNotFoundMessage);

            var genres = await _genreRepository.GetByIdsAsync(
                request.GenreIds);

            if (genres.Count != request.GenreIds.Distinct().Count())
            {
                throw new NotFoundException(GenreErrors.OneOrMoreGenresNotFoundCode, GenreErrors.OneOrMoreGenresNotFoundMessage);
            }

            // FluentValidation will be checking if this has value
            TimeSpan duration = TimeSpan.FromMinutes(request.DurationMinutes);

            Money? money = null;

            if (request.BudgetAmount.HasValue && !string.IsNullOrWhiteSpace(request.CurrencyCode))
            {
                money = MoneyFactory.Create(request.BudgetAmount.Value, request.CurrencyCode);
            }

            var details = MovieDetailsFactory.Create(
                request.Language,
                request.Synopsis,
                money);

            movie.Update(
                request.Title,
                duration,
                genres,
                details
                );

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return MovieMapper.ToDto(movie);
        }
    }
}
