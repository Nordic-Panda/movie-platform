using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieService.API.Filters;
using MovieService.API.Middlewares;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Movies.CreateMovie;
using MovieService.Infrastructure.Data;
using MovieService.Infrastructure.Persistence.Movies;

var builder = WebApplication.CreateBuilder(args);

//
// 1. Controllers (instead of minimal API endpoints)
//
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ModelStateFilter>(); // adding in custom filter
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

// Validators
builder.Services.AddValidatorsFromAssemblyContaining<CreateMovieValidator>();

// Application layer
builder.Services.AddScoped<CreateMovieHandler>();

// Infrastructure layer
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

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