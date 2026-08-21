using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Movies.GetMovies
{
    public record GetMoviesQuery(
        ICollection<Guid>? GenreIds,
        string? Title,
        int? Duration,
        string? ActorFirstName,
        string? ActorLastName,
        int? Page,
        int? PageSize
    ) : IRequest<PagedResult<MovieDto>>;
}
