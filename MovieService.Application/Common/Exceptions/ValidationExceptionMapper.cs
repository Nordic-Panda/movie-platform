namespace MovieService.Application.Common.Exceptions
{
    public static class ValidationExceptionMapper
    {
        // This decouples my ValidationException from other validation service (FluentValidation in this case)
        // Mapping their error to my own structure, which is more consistence and make it easier if i switch Validator service 

        // making it extention method for better readability ex.ToApplicationException();
        public static ValidationException ToApplicationException(this FluentValidation.ValidationException ex)
        {
            var errors = ex.Errors
                .GroupBy(x => x.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(x => x.ErrorMessage).ToArray()
                );

            return new ValidationException(errors);
        }
    }
}