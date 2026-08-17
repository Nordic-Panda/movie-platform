using MovieService.API.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add Controller related config, custom modelStateFilter
builder.Services.AddApiControllers();
// Active Swagger auth UI
builder.Services.ActiveSwaggerAuthentication();
// Custom JwtAuth config
builder.Services.AddJwtAuthentication(builder.Configuration);
// Add Policies
builder.Services.AddAuthorizationPolicies();
builder.Services.AddCorsPolicy(builder.Configuration);
// Add application layer services, MediatR, FluentValidation 
builder.Services.AddApplicationServices();
// Add Infrastructure layer services, Register DBcontext, Repositories, services
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

// DB seeder
await app.SeedDatabaseAsync();
// Middleware registers
app.UseApiMiddlewares();

app.MapControllers();

app.Run();