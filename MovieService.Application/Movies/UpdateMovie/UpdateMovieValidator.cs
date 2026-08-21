using FluentValidation;
using MovieService.Domain.Currencies;
using MovieService.Domain.Movies;

namespace MovieService.Application.Movies.UpdateMovie
{
    public class UpdateMovieValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieValidator()
        {
            // This is mixed business logic validation and input validation
            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(MovieRules.TitleMinLength)
                .MaximumLength(MovieRules.TitleMaxLength);

            RuleFor(x => x.DurationMinutes)
                .GreaterThanOrEqualTo((int)MovieRules.MinDuration.TotalMinutes)
                .LessThanOrEqualTo((int)MovieRules.MaxDuration.TotalMinutes);

            RuleFor(x => x.LanguageId).NotEmpty();

            RuleFor(x => x.CurrencyCode)
                .Length(CurrencyRules.IsoCodeLength)
                .When(x => !string.IsNullOrWhiteSpace(x.CurrencyCode));

            // if got budget, there must be currencycode
            RuleFor(x => x)
                .Must(x => x.BudgetAmount.HasValue == !string.IsNullOrWhiteSpace(x.CurrencyCode));

            RuleFor(x => x.Year).InclusiveBetween(MovieRules.MinYear, DateTime.UtcNow.Year);
        }
    }
}
