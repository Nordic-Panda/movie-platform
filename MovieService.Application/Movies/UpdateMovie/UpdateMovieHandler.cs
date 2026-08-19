using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Genres;
using MovieService.Domain.Languages;
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
        private readonly ILanguageRepository _languageRepository;

        public UpdateMovieHandler(
            IMovieRepository movieRepository,
            IGenreRepository genreRepository,
            IUnitOfWork unitOfWork,
            ILanguageRepository languageRepository
        )
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _unitOfWork = unitOfWork;
            _languageRepository = languageRepository;
        }

        public async Task<MovieDto> Handle(
            UpdateMovieCommand request,
            CancellationToken cancellationToken
        )
        {
            var movie = await _movieRepository.GetByIdAsync(request.Id);

            if (movie == null)
                throw new NotFoundException(
                    MovieErrors.MovieNotFoundCode,
                    MovieErrors.MovieNotFoundMessage
                );

            var genres =
                request.GenreIds == null
                    ? movie.Genres
                    : await _genreRepository.GetByIdsAsync(request.GenreIds);

            if (request.GenreIds != null && genres.Count != request.GenreIds.Distinct().Count())
            {
                throw new NotFoundException(
                    GenreErrors.OneOrMoreGenresNotFoundCode,
                    GenreErrors.OneOrMoreGenresNotFoundMessage
                );
            }

            var language = movie.Language;

            if (request.LanguageId is Guid languageId)
            {
                language = await _languageRepository.GetByIdAsync(languageId);

                if (language == null)
                {
                    throw new NotFoundException(
                        LanguageErrors.LanguageNotFoundCode,
                        LanguageErrors.LanguageNotFoundMessage
                    );
                }
            }

            var duration = !request.DurationMinutes.HasValue
                ? movie.Duration
                : TimeSpan.FromMinutes(request.DurationMinutes.Value);

            var title = request.Title ?? movie.Title;
            var year = request.Year ?? movie.Year;

            Money? money = !request.BudgetAmount.HasValue
                ? movie.Details.Budget
                : MoneyFactory.Create(request.BudgetAmount.Value, request.CurrencyCode!);

            var synopsis = request.Synopsis ?? movie.Details.Synopsis;

            var details = MovieDetailFactory.Create(synopsis, money);

            var posterUrl = request.PosterUrl ?? movie.PosterUrl;

            movie.Update(title, year, duration, genres, details, language, posterUrl);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return MovieMapper.ToDto(movie);
        }
    }
}
