using Microsoft.AspNetCore.Mvc;
using MovieService.API.Common.Extensions;
using MovieService.API.Common.Filters;
using MovieService.Application.Common.Settings;
using MovieService.Infrastructure.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


// Add Controller related config, custom modelStateFilter
builder.Services.AddApiControllers();
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

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider
        .GetRequiredService<AppDbContext>();

    await DbSeeder.SeedUser(db);
}
// Middleware registers
app.UseApiMiddlewares();

app.MapControllers();

app.Run();