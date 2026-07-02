namespace MovieService.API.Common.Errors
{
    public class AuthErrors
    {
        public const string AuthenticationFailedCode = "AUTHENTICATION_FAILED";
        public const string AccesstokenInvalidMessage = "Invalid access token";

        public const string AuthorizationFailedCode = "AUTHORIZATION_FAILED";
        public const string NoPermissionMessage = "You do not have permission to do so";
    }
}
