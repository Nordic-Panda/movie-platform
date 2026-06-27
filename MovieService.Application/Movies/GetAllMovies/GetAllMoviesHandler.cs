using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;

namespace MovieService.Application.Movies.GetAllMovies
{
    public class GetAllMoviesHandler : IRequestHandler<GetAllMoviesQuery, IReadOnlyList<MovieDto>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetAllMoviesHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<IReadOnlyList<MovieDto>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetAllMoviesAsync();

            return movies
                .Select(MovieMapper.ToDto)
                .ToList()
                .AsReadOnly();
        }
    }
}
