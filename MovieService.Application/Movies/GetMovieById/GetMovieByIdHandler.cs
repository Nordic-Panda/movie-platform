using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Movies;

namespace MovieService.Application.Movies.GetMovieById
{
    public class GetMovieByIdHandler : IRequestHandler<GetMovieByIdQuery, MovieDto>
    {
        private readonly IMovieRepository _movieRepository;

        public GetMovieByIdHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<MovieDto> Handle(GetMovieByIdQuery request, CancellationToken ct)
        {
            var movie = await _movieRepository.GetByIdAsync(request.Id);

            if (movie is null)
                throw new NotFoundException(
                    MovieErrors.MovieNotFoundCode,
                    MovieErrors.MovieNotFoundMessage
                );

            return MovieMapper.ToDto(movie);
        }
    }
}
