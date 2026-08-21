using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Movies.GetMovieDetailsById
{
    public record GetMovieDetailsByIdQuery(Guid Id) : IRequest<MovieDetailsDto>;
}
