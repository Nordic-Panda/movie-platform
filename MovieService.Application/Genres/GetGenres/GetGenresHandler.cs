using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;

namespace MovieService.Application.Genres.GetGenres
{
    public class GetGenresHandler : IRequestHandler<GetGenresQuery, IReadOnlyList<GenreDto>>
    {
        private readonly IGenreRepository _genreRepository;

        public GetGenresHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        // Reason why no pagination here is that genre will be rather small and won't be displayed in a list
        // but rather in a dropdown or similar UI element. So no need to paginate it.
        public async Task<IReadOnlyList<GenreDto>> Handle(
            GetGenresQuery request,
            CancellationToken cancellationToken
        )
        {
            //var genres = await _genreRepository
            //    .Query()
            //    .OrderBy(g => g.Name)
            //    .ToListAsync(cancellationToken);

            var genres = await _genreRepository.GetAllGenresAsync();

            return genres.Select(GenreMapper.ToDto).ToList();
        }
    }
}
