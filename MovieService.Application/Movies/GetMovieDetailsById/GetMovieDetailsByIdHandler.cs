using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Movies;

namespace MovieService.Application.Movies.GetMovieDetailsById
{
    public class GetMovieDetailsByIdHandler : IRequestHandler<GetMovieDetailsByIdQuery, MovieDetailsDto>
    {
        private readonly IMovieRepository _repo;

        public GetMovieDetailsByIdHandler(IMovieRepository repo)
        {
            _repo = repo;
        }
        public async Task<MovieDetailsDto> Handle(GetMovieDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var movie = await _repo.GetByIdAsync(request.Id);

            if (movie == null)
                throw new NotFoundException(MovieErrors.MovieNotFoundCode, MovieErrors.MovieNotFoundMessage);

            return MovieDetailsMapper.ToDto(movie);
        }
    }
}
