using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Genres.GetGenreById
{
    public record GetGenreByIdQuery(Guid Id) : IRequest<GenreDto>;
}
