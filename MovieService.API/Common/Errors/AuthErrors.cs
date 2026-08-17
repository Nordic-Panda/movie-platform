namespace MovieService.API.Common.Errors
{
    public class AuthErrors
    {
        public const string AuthenticationFailedCode = "AUTHENTICATION_FAILED";
        public const string AccesstokenInvalidMessage = "Invalid access token";

        public const string AuthorizationFailedCode = "AUTHORIZATION_FAILED";
        public const string NoPermissionMessage = "You do not have permission to do so";


        public const string UnauthorizedCode = "UNAUTHORIZED";
        public const string UnauthorizedMessage = "Authentication is required.";

        public const string ForbiddenCode = "FORBIDDEN";
        public const string ForbiddenMessage = "You do not have permission to perform this action.";

        public const string NotFoundCode = "NOT_FOUND";
        public const string NotFoundMessage = "Resource not found.";

        public const string MethodNotAllowedCode = "METHOD_NOT_ALLOWED";
        public const string MethodNotAllowedMessage = "Method not allowed.";

        public const string HttpErrorCode = "HTTP_ERROR";
        public const string HttpErrorMessage = "Request failed.";
    }
}
