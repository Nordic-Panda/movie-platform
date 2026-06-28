using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieService.API.Filters;
using MovieService.API.Middlewares;
using MovieService.Application.Behaviors;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Movies.CreateMovie;
using MovieService.Infrastructure.Data;
using MovieService.Infrastructure.Persistence.Actors;
using MovieService.Infrastructure.Persistence.Movies;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//
// 1. Controllers (instead of minimal API endpoints)
//
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ModelStateFilter>(); // adding in custom filter
})
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(
        new JsonStringEnumConverter()
    );
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    // This stops ASP.NET from auto-returning 400, so we can use custom logic on returning data
    options.SuppressModelStateInvalidFilter = true;
});

//
// 2. OpenAPI / Swagger
//
//builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//
// Register DbContext
//
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default")
    ));

//
// 3. Dependency Injection (REGISTER LAYERED SERVICES)
//

// Validators. FluentValidation scans the assembly and DI store them all, CreateMovieValidator can be replaced by ANY validator in Application
// IValidator<CreateMovieCommand>
//    -> CreateMovieValidator
// It find these in the Validator, t ex CreateMovieValidator : AbstractValidator<CreateMovieCommand>
builder.Services.AddValidatorsFromAssemblyContaining<CreateMovieValidator>();

// Registering a behavior, every time someone calls Mediator.Send(...), execute ValidationBehavior around the handler.
builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>));

// Register handlers to MediatR
// public class CreateMovieHandler : IRequestHandler<CreateMovieCommand, MovieDto>
// so it register the IRequestHandler with command and dto to the pairing Handler
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<CreateMovieHandler>());

// Application layer
builder.Services.AddScoped<CreateMovieHandler>();

// Infrastructure layer
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IActorRepository, ActorRepository>();

var app = builder.Build();

//
// 4. HTTP pipeline
//
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Custom exception middleware, order matters here
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

//
// 5. Map controllers (IMPORTANT — replaces MapGet style)
//
app.MapControllers();

app.Run();