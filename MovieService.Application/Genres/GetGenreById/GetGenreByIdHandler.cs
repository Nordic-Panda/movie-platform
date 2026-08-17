using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
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
        public async Task<GenreDto> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.GetByIdAsync(request.Id);
            if (genre == null)
            {
                throw new NotFoundException(GenreErrors.GenresNotFoundCode, GenreErrors.GenresNotFoundMessage);
            }
            return new GenreDto(genre.Id, genre.Name);
        }
    }
}
