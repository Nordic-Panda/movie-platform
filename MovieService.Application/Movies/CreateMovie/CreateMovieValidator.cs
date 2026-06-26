using FluentValidation;
using MovieService.Application.Common.DTOs;
using MovieService.Domain.Currency;
using MovieService.Domain.Movies;

public class CreateMovieValidator : AbstractValidator<CreateMovieRequest>
{
    public CreateMovieValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(MovieRules.TitleMinLength)
            .MaximumLength(MovieRules.TitleMaxLength);

        RuleFor(x => x.DurationMinutes)
            .GreaterThanOrEqualTo((int)MovieRules.MinDuration.TotalMinutes)
            .LessThanOrEqualTo((int)MovieRules.MaxDuration.TotalMinutes);

        RuleFor(x => x.Genre)
            .NotEmpty();

        RuleFor(x => x.Language)
            .NotEmpty();

        RuleFor(x => x.CurrencyCode)
            .Length(CurrencyRules.IsoCodeLength)
            .When(x => x.CurrencyCode != null);
    }
}