using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Movies.CreateMovie;

var builder = WebApplication.CreateBuilder(args);

//
// 1. Controllers (instead of minimal API endpoints)
//
builder.Services.AddControllers();

//
// 2. OpenAPI / Swagger
//
builder.Services.AddOpenApi();

//
// 3. Dependency Injection (REGISTER LAYERED SERVICES)
//

// Application layer
builder.Services.AddScoped<CreateMovieHandler>();

// Infrastructure layer
//builder.Services.AddScoped<IMovieRepository, MovieRepository>();

var app = builder.Build();

//
// 4. HTTP pipeline
//
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//
// 5. Map controllers (IMPORTANT — replaces MapGet style)
//
app.MapControllers();

app.Run();