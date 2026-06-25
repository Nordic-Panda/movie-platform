using FluentValidation;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Movies.CreateMovie;

public class CreateMovieValidator : AbstractValidator<CreateMovieRequest>
{
    public CreateMovieValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(CreateMovieValidatorConstants.TitleMinLength)
            .MaximumLength(CreateMovieValidatorConstants.TitleMaxLength);

        RuleFor(x => x.DurationMinutes)
            .GreaterThan(CreateMovieValidatorConstants.DurationMinMinutes)
            .LessThanOrEqualTo(CreateMovieValidatorConstants.DurationMaxMinutes);

        RuleFor(x => x.Genre)
            .NotEmpty();

        RuleFor(x => x.Language)
            .NotEmpty();

        RuleFor(x => x.CurrencyCode)
            .Length(CreateMovieValidatorConstants.CurrencyIsoMinLength)
            .When(x => x.CurrencyCode != null);
    }
}