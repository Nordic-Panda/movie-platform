using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Interfaces.Repositories;

namespace MovieService.Application.Movies.CreateMovie;

public class CreateMovieHandler
{
    private readonly IMovieRepository _movieRepository;

    public CreateMovieHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<MovieDto> AddMovie(CreateMovieRequest request)
    {
        // We needed to:
        // Convert from primitive values to correct form
        // Create movie with Domain MovieFactory

        // But for clean coding:
        // CreateMovieFactory here is from Application
        // Works like a helper to further split the code

        var movie = CreateMovieFactory.Create(request);

        // Call repo to persist data

        await _movieRepository.AddAsync(movie);

        // Create DTO
        return CreateMovieMapper.ToDto(movie);

        // Below is a bad example, because we are using direct request value, which breaks the point with our structure
        //return CreateMovieMapper.ToDto(movie, request.DurationMinutes);
    }
}