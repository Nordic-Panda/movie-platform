using Microsoft.EntityFrameworkCore;
using MovieService.Application.Common.Interfaces;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Infrastructure.Auth;
using MovieService.Infrastructure.Data;
using MovieService.Infrastructure.Persistence.Actors;
using MovieService.Infrastructure.Persistence.MovieActors;
using MovieService.Infrastructure.Persistence.Movies;
using MovieService.Infrastructure.Persistence.Reviews;
using MovieService.Infrastructure.Persistence.Users;

namespace MovieService.API.Common.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("Default")));

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IMovieActorRepository, MovieActorRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ITokenService, JwtTokenService>();

            return services;
        }
    }
}
