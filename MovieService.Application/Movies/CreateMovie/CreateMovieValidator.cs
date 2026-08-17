using FluentValidation;
using MovieService.Domain.Currency;
using MovieService.Domain.Movies;

namespace MovieService.Application.Movies.CreateMovie
{
    public class CreateMovieValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieValidator()
        {
            // This is mixed business logic validation and input validation
            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(MovieRules.TitleMinLength)
                .MaximumLength(MovieRules.TitleMaxLength);

            RuleFor(x => x.DurationMinutes)
                .GreaterThanOrEqualTo((int)MovieRules.MinDuration.TotalMinutes)
                .LessThanOrEqualTo((int)MovieRules.MaxDuration.TotalMinutes);

            RuleFor(x => x.Language).NotEmpty();

            RuleFor(x => x.CurrencyCode)
                .Length(CurrencyRules.IsoCodeLength)
                .When(x => x.CurrencyCode != null);

            RuleFor(x => x.Year).InclusiveBetween(MovieRules.MinYear, DateTime.UtcNow.Year);
        }
    }
}
