using MovieService.API.Common.Contracts;
using MovieService.API.Common.Middlewares;

namespace MovieService.API.Common.Extensions
{
    public static class MiddlewareExtensions
    {
        public static WebApplication UseApiMiddlewares(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // MVC error
            app.UseStatusCodePages(async context =>
            {
                var response = context.HttpContext.Response;

                var (code, message) = response.StatusCode switch
                {
                    404 => ("NOT_FOUND", "Resource not found"),
                    405 => ("METHOD_NOT_ALLOWED", "Method not allowed"),
                    _ => ("HTTP_ERROR", "Request failed")
                };

                response.ContentType = "application/json";

                await response.WriteAsJsonAsync(
                    ApiResponse<Dictionary<string, string[]>>.Fail(code, message));
            });

            // Custom exception middleware, order matters here
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}
