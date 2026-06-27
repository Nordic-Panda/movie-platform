using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Movies.GetMovieById
{
    public record GetMovieByIdQuery(Guid Id)
    : IRequest<MovieDto>;
}
