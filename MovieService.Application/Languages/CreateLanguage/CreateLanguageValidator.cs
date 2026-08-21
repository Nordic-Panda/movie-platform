using FluentValidation;
using MovieService.Domain.Languages;

namespace MovieService.Application.Languages.CreateLanguage
{
    public class CreateLanguageValidator : AbstractValidator<CreateLanguageCommand>
    {
        public CreateLanguageValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(LanguageRules.NameMinLength)
                .MaximumLength(LanguageRules.NameMaxLength);

            RuleFor(x => x.Code).NotEmpty().Length(LanguageRules.ISO6391Length);
        }
    }
}
