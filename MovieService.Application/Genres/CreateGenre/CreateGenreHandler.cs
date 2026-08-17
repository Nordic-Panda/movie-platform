using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Genres;

namespace MovieService.Application.Genres.CreateGenre
{
    public class CreateGenreHandler : IRequestHandler<CreateGenreCommand, GenreDto>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateGenreHandler(IGenreRepository genreRepository, IUnitOfWork unitOfWork)
        {
            _genreRepository = genreRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<GenreDto> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {

            var existingGenre = await _genreRepository.GetByNameAsync(request.Name);

            if (existingGenre is not null)
            {
                throw new ConflictException(GenreErrors.GenreNameAlreadyExistsCode, GenreErrors.GenreNameAlreadyExistsMessage);
            }

            var genre = CreateGenreFactory.Create(request);

            await _genreRepository.AddAsync(genre);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return GenreMapper.ToDto(genre);
        }
    }
}
