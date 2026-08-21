using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Genres.CreateGenre
{
    public record CreateGenreCommand(string Name) : IRequest<GenreDto>;
}
