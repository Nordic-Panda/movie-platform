using FluentValidation;
using MovieService.Domain.Currencies;
using MovieService.Domain.Movies;

namespace MovieService.Application.Movies.UpdateMovie
{
    public class UpdateMovieValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(MovieRules.TitleMinLength)
                .MaximumLength(MovieRules.TitleMaxLength);

            RuleFor(x => x.DurationMinutes)
                .GreaterThanOrEqualTo((int)MovieRules.MinDuration.TotalMinutes)
                .LessThanOrEqualTo((int)MovieRules.MaxDuration.TotalMinutes);

            RuleFor(x => x.Year).InclusiveBetween(MovieRules.MinYear, DateTime.UtcNow.Year);

            RuleFor(x => x.LanguageId).NotEmpty();

            RuleFor(x => x.CurrencyCode)
                .Length(CurrencyRules.IsoCodeLength)
                .When(x => x.CurrencyCode != null);
        }
    }
}
