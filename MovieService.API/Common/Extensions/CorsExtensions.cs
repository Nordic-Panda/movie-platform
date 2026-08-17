namespace MovieService.API.Common.Extensions
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddCorsPolicy(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var frontendOrigin = configuration["Cors:FrontendOrigin"];

            if (string.IsNullOrWhiteSpace(frontendOrigin))
            {
                throw new InvalidOperationException(
                    "Cors:FrontendOrigin is not configured.");
            }

            services.AddCors(options =>
            {
                options.AddPolicy("Frontend", policy =>
                {
                    policy
                        .WithOrigins(frontendOrigin)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            return services;
        }
    }
}
