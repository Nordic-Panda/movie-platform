using MediatR;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Domain.Movies;

namespace MovieService.Application.Movies.DeleteMovieById
{
    public class DeleteMovieHandler : IRequestHandler<DeleteMovieCommand>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMovieHandler(IMovieRepository movieRepository, IUnitOfWork unitOfWork)
        {
            _movieRepository = movieRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetByIdAsync(request.Id);

            if (movie is null)
                throw new NotFoundException(
                    MovieErrors.MovieNotFoundCode,
                    MovieErrors.MovieNotFoundMessage
                );

            //await _movieRepository.DeleteAsync(request.Id);

            // using soft delete
            movie.Disable();
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
