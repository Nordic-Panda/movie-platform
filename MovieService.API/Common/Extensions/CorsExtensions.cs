namespace MovieService.API.Common.Extensions
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddCorsPolicy(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            // edited for testing google login, now supports multiple origin
            var frontendOrigins = configuration.GetSection("Cors:FrontendOrigins").Get<string[]>();

            if (frontendOrigins is null || frontendOrigins.Length == 0)
            {
                throw new InvalidOperationException("Cors:FrontendOrigins is not configured.");
            }

            services.AddCors(options =>
            {
                options.AddPolicy(
                    "Frontend",
                    policy =>
                    {
                        policy.WithOrigins(frontendOrigins).AllowAnyHeader().AllowAnyMethod();
                    }
                );
            });

            return services;
        }
    }
}
