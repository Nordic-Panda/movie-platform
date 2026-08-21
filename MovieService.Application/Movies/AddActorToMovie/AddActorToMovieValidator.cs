using FluentValidation;

namespace MovieService.Application.Movies.AddActorToMovie
{
    public class AddActorToMovieValidator : AbstractValidator<AddActorToMovieCommand>
    {
        public AddActorToMovieValidator()
        {
            RuleFor(x => x.MovieId).NotEmpty();

            RuleFor(x => x.ActorId).NotEmpty();

            RuleFor(x => x.CharacterName).NotEmpty();
        }
    }
}
