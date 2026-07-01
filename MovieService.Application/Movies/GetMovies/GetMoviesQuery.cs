using MediatR;
using MovieService.Application.Common.DTOs;
namespace MovieService.Application.Movies.GetMovies
{
    public record GetMoviesQuery
    (
        string? Genre,
        string? Title,
        int? Duration,
        string? ActorFirstName,
        string? ActorLastName,
        int? Page
    ) : IRequest<IReadOnlyList<MovieDto>>;
}
