using Microsoft.AspNetCore.Mvc;
using MovieService.API.Common.Filters;
using System.Text.Json.Serialization;

namespace MovieService.API.Common.Extensions
{
    public static class ControllerExtensions
    {
        public static IServiceCollection AddApiControllers(
            this IServiceCollection services)
        {
            // add custom modelstate handler
            services.AddControllers(options =>
            {
                options.Filters.Add<ModelStateFilter>();
            })
                .AddJsonOptions(options =>
                {
                    // allow string convert for enum
                    options.JsonSerializerOptions.Converters.Add(
                        new JsonStringEnumConverter());
                });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                // disable default response when modelstate invalid,
                // else it returns 400 and we can not use custom response
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }
    }
}
