using FluentValidation;
using MovieService.Application.Common.DTOs;

public class CreateMovieValidator : AbstractValidator<CreateMovieRequest>
{
    public CreateMovieValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(200);

        RuleFor(x => x.DurationMinutes)
            .GreaterThan(0)
            .LessThanOrEqualTo(600);

        RuleFor(x => x.Genre)
            .NotEmpty();

        RuleFor(x => x.Language)
            .NotEmpty();

        RuleFor(x => x.CurrencyCode)
            .Length(3)
            .When(x => x.CurrencyCode != null);
    }
}