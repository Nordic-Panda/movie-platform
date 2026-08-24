using Microsoft.EntityFrameworkCore;
using MovieService.Application.Common.Interfaces;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Settings;
using MovieService.Infrastructure.Auth;
using MovieService.Infrastructure.Data;
using MovieService.Infrastructure.Persistence;
using MovieService.Infrastructure.Persistence.Actors;
using MovieService.Infrastructure.Persistence.Currencies;
using MovieService.Infrastructure.Persistence.Genres;
using MovieService.Infrastructure.Persistence.Languages;
using MovieService.Infrastructure.Persistence.MovieActors;
using MovieService.Infrastructure.Persistence.Movies;
using MovieService.Infrastructure.Persistence.Reviews;
using MovieService.Infrastructure.Persistence.Roles;
using MovieService.Infrastructure.Persistence.Users;

namespace MovieService.API.Common.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration config
        )
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("Default"))
            );

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IMovieActorRepository, MovieActorRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            services.AddHttpContextAccessor();

            services.AddScoped<ICurrentUser, CurrentUser>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ITokenService, JwtTokenService>();

            // Register value from Configuration to TypedValue, note that this does not mean appsettings, this could be azure too
            // When using Azure config or something else, they inject more data to Configuration
            // So this is unchanged. This does not care where exactly data comes from
            services.Configure<PaginationSettings>(config.GetSection("Pagination"));

            services.Configure<JwtSettings>(config.GetSection("Jwt"));

            return services;
        }
    }
}
