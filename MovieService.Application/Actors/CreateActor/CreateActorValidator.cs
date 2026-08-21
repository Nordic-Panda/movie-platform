using FluentValidation;
using MovieService.Domain.Actors;

namespace MovieService.Application.Actors.CreateActor
{
    public class CreateActorValidator : AbstractValidator<CreateActorCommand>
    {
        public CreateActorValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();

            RuleFor(x => x.LastName).NotEmpty();

            RuleFor(x => x.BirthYear)
                .GreaterThanOrEqualTo(ActorRules.EarliestYear)
                .LessThanOrEqualTo(DateTime.UtcNow.Year);
        }
    }
}
