using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Genres.GetGenres
{
    public record GetGenresQuery : IRequest<IReadOnlyList<GenreDto>>;
}
