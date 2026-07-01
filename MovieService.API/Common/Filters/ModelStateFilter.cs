using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MovieService.API.Common.Contracts;

namespace MovieService.API.Common.Filters
{
    public class ModelStateFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(x => x.Value?.Errors.Count > 0)
                    .ToDictionary(
                        x => x.Key,
                        x => x.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                context.Result = new BadRequestObjectResult(
                    ApiResponse<Dictionary<string, string[]>>.Fail(
                        "MODEL_VALIDATION_ERROR",
                        "Request validation failed",
                        errors
                    ));
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}