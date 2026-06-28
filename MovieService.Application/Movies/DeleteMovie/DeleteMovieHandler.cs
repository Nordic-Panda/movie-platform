using MediatR;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Domain.Movies;

namespace MovieService.Application.Movies.DeleteMovieById
{
    public class DeleteMovieHandler : IRequestHandler<DeleteMovieCommand>
    {
        private readonly IMovieRepository _movieRepository;

        public DeleteMovieHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetByIdAsync(request.Id);

            if (movie == null)
                throw new NotFoundException(ActorErrors.MovieNotFoundCode, ActorErrors.MovieNotFoundMessage);

            await _movieRepository.DeleteAsync(request.Id);
        }
    }
}
