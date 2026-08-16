using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Application.Movies.CreateMovie;
using MovieService.Domain.Genres;

public class CreateMovieHandler : IRequestHandler<CreateMovieCommand, MovieDto>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IGenreRepository _genreRepository;

    public CreateMovieHandler(IMovieRepository movieRepository, IGenreRepository genreRepository)
    {
        _movieRepository = movieRepository;
        _genreRepository = genreRepository;
    }

    public async Task<MovieDto> Handle(CreateMovieCommand request, CancellationToken ct)
    {
        var genres = await _genreRepository.GetByIdsAsync(
            request.GenreIds);

        if (genres.Count != request.GenreIds.Distinct().Count())
        {
            throw new NotFoundException(GenreErrors.OneOrMoreGenresNotFoundCode, GenreErrors.OneOrMoreGenresNotFoundMessage);
        }

        var movie = CreateMovieFactory.Create(request, genres);

        await _movieRepository.AddAsync(movie);
        await _movieRepository.SaveChangesAsync();

        return MovieMapper.ToDto(movie);
    }
}