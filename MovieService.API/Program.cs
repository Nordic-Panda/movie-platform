using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieService.API.Common.Contracts;
using MovieService.API.Common.Filters;
using MovieService.API.Common.Middlewares;
using MovieService.API.Common.Settings;
using MovieService.Application.Behaviors;
using MovieService.Application.Common.Interfaces;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Infrastructure.Data;
using MovieService.Infrastructure.Persistence.Actors;
using MovieService.Infrastructure.Persistence.MovieActors;
using MovieService.Infrastructure.Persistence.Movies;
using MovieService.Infrastructure.Persistence.Reviews;
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

// Register value from Configuration, note that this does not mean appsettings, this could be azure too
// When using Azure config or something else, they inject more data to Configuration
// So this is unchanged. This does not care where exactly data comes from
builder.Services.Configure<PaginationSettings>(
    builder.Configuration.GetSection("Pagination"));

// IOptions<PaginationSettings> is just a container, real PaginationSettings lays in Value of that container
builder.Services.AddSingleton<IPaginationSettings>(sp =>
    sp.GetRequiredService<IOptions<PaginationSettings>>().Value);

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

// Application layer, not needed since we using mediatR
//builder.Services.AddScoped<CreateMovieHandler>();

// Infrastructure layer
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IActorRepository, ActorRepository>();
builder.Services.AddScoped<IMovieActorRepository, MovieActorRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

var app = builder.Build();

//
// 4. HTTP pipeline
//
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// For MVC error
app.UseStatusCodePages(async context =>
{
    var response = context.HttpContext.Response;

    var (code, message) = response.StatusCode switch
    {
        404 => ("NOT_FOUND", "The requested resource was not found"),
        405 => ("METHOD_NOT_ALLOWED", "HTTP method not allowed"),
        _ => ("HTTP_ERROR", "Request failed")
    };

    response.ContentType = "application/json";

    await response.WriteAsJsonAsync(
        ApiResponse<Dictionary<string, string[]>>.Fail(code, message)
    );
});


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider
        .GetRequiredService<AppDbContext>();

    await DbSeeder.SeedUser(db);
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