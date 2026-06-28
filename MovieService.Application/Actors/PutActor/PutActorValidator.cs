using FluentValidation;
using MovieService.Domain.Actors;

namespace MovieService.Application.Actors.PutActor
{
    public class PutActorValidator : AbstractValidator<PutActorCommand>
    {
        public PutActorValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.FirstName)
                .NotEmpty();

            RuleFor(x => x.LastName)
                .NotEmpty();

            RuleFor(x => x.BirthYear)
                .GreaterThanOrEqualTo(ActorRules.EarliestYear)
                .LessThanOrEqualTo(DateTime.UtcNow.Year);
        }
    }
}
