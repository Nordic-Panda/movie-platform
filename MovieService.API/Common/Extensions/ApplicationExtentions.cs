using FluentValidation;
using MediatR;
using MovieService.Application.Behaviors;

namespace MovieService.API.Common.Extensions
{
    public static class ApplicationExtentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            // Validators. FluentValidation scans the assembly and DI store them all, CreateMovieValidator can be replaced by ANY validator in Application
            // IValidator<CreateMovieCommand>
            //    -> CreateMovieValidator
            // It find these in the Validator, t ex CreateMovieValidator : AbstractValidator<CreateMovieCommand>
            services.AddValidatorsFromAssemblyContaining<CreateMovieValidator>();

            // Registering a behavior, every time someone calls Mediator.Send(...), execute ValidationBehavior around the handler.
            services.AddTransient(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

            // Register handlers to MediatR
            // public class CreateMovieHandler : IRequestHandler<CreateMovieCommand, MovieDto>
            // so it register the IRequestHandler with command and dto to the pairing Handler
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblyContaining<CreateMovieHandler>());

            return services;
        }
    }
}