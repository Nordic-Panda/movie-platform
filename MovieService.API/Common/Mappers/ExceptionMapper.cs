using MovieService.Application.Common.Exceptions;
using MovieService.Domain.Common.Exceptions;

namespace MovieService.API.Common.Mappers
{
    public static class ExceptionMapper
    {
        public static (string Code, string Message, int StatusCode, Dictionary<string, string[]>? Details)
            Map(Exception ex)
        {
            return ex switch
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

                NotFoundException e => (
                    e.Code,
                    e.Message,
                    StatusCodes.Status404NotFound,
                    null
                ),

                ConflictException e => (
                    e.Code,
                    e.Message,
                    StatusCodes.Status409Conflict,
                    null
                ),

                UnauthorizedException e => (
                    e.Code,
                    e.Message,
                    StatusCodes.Status401Unauthorized,
                    null
                ),

                _ => (
                    "SERVER_ERROR",
                    "Something went wrong",
                    StatusCodes.Status500InternalServerError,
                    null
                )
            };
        }
    }
}
