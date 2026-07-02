using MovieService.Domain.Common.Enums;
using MovieService.API.Common.policy;

namespace MovieService.API.Common.Extensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAuthorizationPolicies(
            this IServiceCollection services)
        {
            // Adding policies
            services.AddAuthorizationBuilder()
                .AddPolicy(Policies.AdminOnly, p =>
                    p.RequireRole(UserRole.Admin.ToString()))
                .AddPolicy(Policies.MovieDelete, p =>
                    p.RequireRole(UserRole.Admin.ToString()))
                .AddPolicy(Policies.MovieCreate, p =>
                    p.RequireRole(UserRole.User.ToString(), UserRole.Admin.ToString()));

            return services;

        }
    }
}
