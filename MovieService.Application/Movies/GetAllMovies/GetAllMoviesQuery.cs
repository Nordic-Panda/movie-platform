using MediatR;
using MovieService.Application.Common.DTOs;
namespace MovieService.Application.Movies.GetAllMovies
{
    public record GetAllMoviesQuery() : IRequest<IReadOnlyList<MovieDto>>;
}
