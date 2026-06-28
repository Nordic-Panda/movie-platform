using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Money;
using MovieService.Domain.Movie.Details;
using MovieService.Domain.Movies;
using MovieService.Domain.ValueObjects;

namespace MovieService.Application.Movies.UpdateMovie
{
    public class UpdateMovieHandler : IRequestHandler<UpdateMovieCommand, MovieDto>
    {
        private readonly IMovieRepository _movieRepository;

        public UpdateMovieHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<MovieDto> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetByIdAsync(request.Id);

            if (movie == null)
                throw new NotFoundException(ActorErrors.MovieNotFoundCode, ActorErrors.MovieNotFoundMessage);

            // FluentValidation will be checking if this has value
            TimeSpan duration = TimeSpan.FromMinutes(request.DurationMinutes);

            Money? money = null;

            if (request.BudgetAmount.HasValue && !string.IsNullOrWhiteSpace(request.CurrencyCode))
            {
                money = MoneyFactory.Create(request.BudgetAmount.Value, request.CurrencyCode);
            }

            var details = MovieDetailsFactory.Create(
                request.Language,
                request.Synopsis,
                money);

            movie.Update(
                request.Title,
                duration,
                request.Genre,
                details
                );

            await _movieRepository.SaveChangesAsync();

            return MovieMapper.ToDto(movie);
        }
    }
}
