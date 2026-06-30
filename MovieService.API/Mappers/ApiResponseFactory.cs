using MovieService.API.Contracts;

namespace MovieService.API.Mappers
{
    public static class ApiResponseFactory
    {
        public static IResult Fail(string code, string message, Dictionary<string, string[]>? details = null, int statusCode = 400)
        {
            return Results.Json(
                ApiResponse<Dictionary<string, string[]>>.Fail(code, message, details),
                statusCode: statusCode
            );
        }
    }
}
