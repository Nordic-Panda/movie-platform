using MovieService.API.Contracts;
using MovieService.API.Mappers;
using MovieService.Application.Common.Exceptions;
using MovieService.Domain.Exceptions;

namespace MovieService.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);

            }
        }

        private static async Task HandleException(HttpContext context, Exception ex)
        {
            var (code, message, statusCode, details) = ExceptionMapper.Map(ex);

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsJsonAsync(
                ApiResponse<Dictionary<string, string[]>>.Fail(code, message, details)
            );
        }
    }
}
