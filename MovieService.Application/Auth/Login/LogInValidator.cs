using FluentValidation;

namespace MovieService.Application.Auth.Login
{
    public class LogInValidator : AbstractValidator<LoginCommand>
    {
        public LogInValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().Must(email => email.Trim() == email);

            // could add business logic for length
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
