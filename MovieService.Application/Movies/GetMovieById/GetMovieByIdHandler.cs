using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Movies;

namespace MovieService.Application.Movies.GetMovieById
{
    public class GetMovieByIdHandler
        : IRequestHandler<GetMovieByIdQuery, MovieDto>
    {
        private readonly IMovieRepository _repo;

        public GetMovieByIdHandler(IMovieRepository repo)
        {
            _repo = repo;
        }

        public async Task<MovieDto> Handle(GetMovieByIdQuery request, CancellationToken ct)
        {
            var movie = await _repo.GetByIdAsync(request.Id);

            if (movie == null)
                throw new KeyNotFoundException(MovieErrors.MovieNotFoundMessage);

            

            return MovieMapper.ToDto(movie);
        }
    }
}
