using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieService.API.Common.Contracts;
using MovieService.API.Common.Extensions;
using MovieService.API.Common.Filters;
using MovieService.API.Common.Middlewares;
using MovieService.API.Common.Policies;
using MovieService.Application.Behaviors;
using MovieService.Application.Common.Interfaces;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Settings;
using MovieService.Domain.Common.Enums;
using MovieService.Infrastructure.Auth;
using MovieService.Infrastructure.Data;
using MovieService.Infrastructure.Persistence.Actors;
using MovieService.Infrastructure.Persistence.MovieActors;
using MovieService.Infrastructure.Persistence.Movies;
using MovieService.Infrastructure.Persistence.Reviews;
using MovieService.Infrastructure.Persistence.Users;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

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

// Active Swagger auth UI
builder.Services.ActiveSwaggerAuthentication();
// Custom JwtAuth config
builder.Services.AddJwtAuthentication(builder.Configuration);
// Add Policies
builder.Services.AddAuthorizationPolicies();
// Add application layer services, MediatR, FluentValidation 
builder.Services.AddApplicationServices();
// Add Infrastructure layer services, Register DBcontext, Repositories, services
builder.Services.AddInfrastructureServices(builder.Configuration);

// Register value from Configuration, note that this does not mean appsettings, this could be azure too
// When using Azure config or something else, they inject more data to Configuration
// So this is unchanged. This does not care where exactly data comes from
builder.Services.Configure<PaginationSettings>(
    builder.Configuration.GetSection("Pagination"));

builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("Jwt"));





var app = builder.Build();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();