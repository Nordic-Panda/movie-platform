using MovieService.API.Contracts;
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
            var (code, message, statusCode, details) = ex switch
            {
                DomainException e => (
                    e.Code,
                    e.Message,
                    StatusCodes.Status400BadRequest,
                    null
                ),

                ValidationException e => (
                    "VALIDATION_ERROR",
                    e.Message,
                    StatusCodes.Status400BadRequest,
                    e.Errors
                ),

                KeyNotFoundException e => (
                    "NOT_FOUND",
                    e.Message,
                    StatusCodes.Status404NotFound,
                    null
                ),

                _ => (
                     "SERVER_ERROR",
                     "Something went wrong",
                     StatusCodes.Status500InternalServerError,
                     null
                 )
            };

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsJsonAsync(
                ApiResponse<object>.Fail(code, message, details)
            );
        }
    }
}
