using FluentValidation;
using MovieService.Domain.Genres;

namespace MovieService.Application.Genres.CreateGenre
{
    public class CreateGenreValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(GenreRules.TitleMaxLength);
        }
    }
}
