using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Genres;

namespace MovieService.Application.Genres.GetGenreById
{
    public class GetGenreByIdHandler : IRequestHandler<GetGenreByIdQuery, GenreDto>
    {
        private readonly IGenreRepository _genreRepository;

        public GetGenreByIdHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<GenreDto> Handle(
            GetGenreByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var existingGenre = await _genreRepository.GetActiveGenreByIdAsync(request.Id);

            return existingGenre is null
                ? throw new NotFoundException(
                    GenreErrors.GenresNotFoundCode,
                    GenreErrors.GenresNotFoundMessage
                )
                : GenreMapper.ToDto(existingGenre);
        }
    }
}
