namespace MovieService.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public Dictionary<string, string[]> Errors { get; }

        // fixed response msg for validationexception, less flexible but more consistent
        // Errors will be able to list out exactly what are failling
        public ValidationException(Dictionary<string, string[]> errors)
            : base("Validation failed")
        {
            Errors = errors;
        }
    }
}
