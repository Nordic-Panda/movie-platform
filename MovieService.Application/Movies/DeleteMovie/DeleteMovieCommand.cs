using MediatR;

namespace MovieService.Application.Movies.DeleteMovieById
{
    public record DeleteMovieCommand(Guid Id) : IRequest;
}
