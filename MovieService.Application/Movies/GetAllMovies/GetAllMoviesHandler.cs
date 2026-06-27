using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;

namespace MovieService.Application.Movies.GetAllMovies
{
    public class GetAllMoviesHandler : IRequestHandler<GetAllMoviesQuery, IReadOnlyList<MovieDto>>
    {
        private readonly IMovieRepository _repo;

        public GetAllMoviesHandler(IMovieRepository repo)
        {
            _repo = repo;
        }
        public async Task<IReadOnlyList<MovieDto>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = await _repo.GetAllMoviesAsync();

            return movies
                .Select(MovieMapper.ToDto)
                .ToList()
                .AsReadOnly();
        }
    }
}
