using FluentValidation;

namespace MovieService.Application.Auth.Login
{
    public class LoginValidator : AbstractValidator<LoginCommand>
    {
        public LoginValidator()
        {
            //// could add business logic for length
            //RuleFor(x => x.Password).NotEmpty();

            RuleFor(x => x.Provider).NotEmpty();
        }
    }
}
