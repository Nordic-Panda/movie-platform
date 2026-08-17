using MovieService.API.Common.Contracts;
using MovieService.API.Common.Errors;
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
                    401 => (
                        AuthErrors.UnauthorizedCode,
                        AuthErrors.UnauthorizedMessage),

                    403 => (
                        AuthErrors.ForbiddenCode,
                        AuthErrors.ForbiddenMessage),

                    404 => (
                        AuthErrors.NotFoundCode,
                        AuthErrors.NotFoundMessage),

                    405 => (
                        AuthErrors.MethodNotAllowedCode,
                        AuthErrors.MethodNotAllowedMessage),

                    _ => (
                        AuthErrors.HttpErrorCode,
                        AuthErrors.HttpErrorMessage)
                };

                response.ContentType = "application/json";

                await response.WriteAsJsonAsync(
                    ApiResponse<Dictionary<string, string[]>>.Fail(code, message));
            });

            // Custom exception middleware, order matters here
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseCors("Frontend");

            app.UseAuthentication();
            app.UseAuthorization();


            return app;
        }
    }
}
