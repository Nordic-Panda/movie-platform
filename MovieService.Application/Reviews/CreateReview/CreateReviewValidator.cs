using FluentValidation;
using MovieService.Domain.Reviews;

namespace MovieService.Application.Reviews.CreateReview
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewValidator() 
        {
            RuleFor(x => x.MovieId)
                .NotEmpty();

            RuleFor(x => x.Comment)
                .NotEmpty();

            RuleFor(x => x.Rating)
                .GreaterThanOrEqualTo(ReviewRules.MinRating)
                .LessThanOrEqualTo(ReviewRules.MaxRating);
        
        }
    }
}
