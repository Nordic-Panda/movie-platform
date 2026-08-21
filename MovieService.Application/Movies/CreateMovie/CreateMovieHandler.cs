using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Application.Movies.CreateMovie;
using MovieService.Domain.Common.Exceptions;
using MovieService.Domain.Common.Normalizers;
using MovieService.Domain.Currencies;
using MovieService.Domain.Genres;
using MovieService.Domain.Languages;
using MovieService.Domain.Movies;

public class CreateMovieHandler : IRequestHandler<CreateMovieCommand, MovieDto>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IGenreRepository _genreRepository;

    private readonly ILanguageRepository _languageRepository;
    private readonly ICurrencyRepository _currencyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateMovieHandler(
        IMovieRepository movieRepository,
        IGenreRepository genreRepository,
        IUnitOfWork unitOfWork,
        ILanguageRepository languageRepository,
        ICurrencyRepository currencyRepository
    )
    {
        _movieRepository = movieRepository;
        _genreRepository = genreRepository;
        _unitOfWork = unitOfWork;
        _languageRepository = languageRepository;
        _currencyRepository = currencyRepository;
    }

    public async Task<MovieDto> Handle(CreateMovieCommand request, CancellationToken ct)
    {
        var normalizedTitle = StringNormalizer.NormalizeTitle(request.Title);
        var duration = TimeSpan.FromMinutes(request.DurationMinutes);

        var existingMovie = await _movieRepository.GetActiveMovieByTitleAndYearAndDurationAsync(
            normalizedTitle,
            request.Year,
            duration
        );

        if (existingMovie is not null)
        {
            throw new ConflictException(
                MovieErrors.MovieAlreadyExistsCode,
                MovieErrors.MovieAlreadyExistsMessage
            );
        }

        var existingGenres = await _genreRepository.GetActiveGenresByIdsAsync(request.GenreIds);

        if (existingGenres.Count != request.GenreIds.Distinct().Count())
            throw new NotFoundException(
                GenreErrors.OneOrMoreGenresNotFoundCode,
                GenreErrors.OneOrMoreGenresNotFoundMessage
            );

        var existingLanguage = await _languageRepository.GetActiveLanguageByIdAsync(
            request.LanguageId
        );

        if (existingLanguage is null)
            throw new NotFoundException(
                LanguageErrors.LanguageNotFoundCode,
                LanguageErrors.LanguageNotFoundMessage
            );

        Currency? currency = null;

        if (request.BudgetAmount.HasValue)
        {
            currency = string.IsNullOrWhiteSpace(request.CurrencyCode)
                ? currency
                : await _currencyRepository.GetActiveCurrencyByCodeAsync(request.CurrencyCode);

            if (currency is null)
                throw new NotFoundException(
                    CurrencyErrors.CurrencyNotFoundCode,
                    CurrencyErrors.CurrencyNotFoundMessage
                );
        }

        var movie = CreateMovieFactory.Create(request, existingGenres, existingLanguage, currency);

        await _movieRepository.AddAsync(movie);
        await _unitOfWork.SaveChangesAsync(ct);

        return MovieMapper.ToDto(movie);
    }
}
