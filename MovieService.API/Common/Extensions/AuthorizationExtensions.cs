using MovieService.API.Common.Policy;
using MovieService.Domain.Common.Enums;

namespace MovieService.API.Common.Extensions
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
        {
            // Adding policies
            services
                .AddAuthorizationBuilder()
                .AddPolicy(Policies.AuthenticatedUser, policy => policy.RequireAuthenticatedUser())
                .AddPolicy(
                    Policies.AdminOnly,
                    policy => policy.RequireRole(UserRole.Admin.ToString())
                );

            return services;
        }
    }
}
