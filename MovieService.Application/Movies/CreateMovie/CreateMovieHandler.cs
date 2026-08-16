using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Application.Movies.CreateMovie;

public class CreateMovieHandler : IRequestHandler<CreateMovieCommand, MovieDto>
{
    private readonly IMovieRepository _movieRepository;

    public CreateMovieHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<MovieDto> Handle(CreateMovieCommand request, CancellationToken ct)
    {

        var movie = CreateMovieFactory.Create(request);

        var genres = await _genreRepository.GetByIdsAsync(
            request.GenreIds,
            cancellationToken);

        await _movieRepository.AddAsync(movie);
        await _movieRepository.SaveChangesAsync();

        return MovieMapper.ToDto(movie);
    }
}