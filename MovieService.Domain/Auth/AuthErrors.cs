namespace MovieService.Domain.Auth
{
    public class AuthErrors
    {
        public const string CurrentUserIdMissingOrInvalidCode =
            "CURRENT_USER_ID_MISSING_OR_INVALID";
        public const string CurrentUserIdMissingOrInvalidMessage =
            "Current user id missing or invalid";

        public const string ProviderRequiredCode = "PROVIDER_REQUIRED";
        public const string ProviderRequiredMessage = "Provider is missing";

        public const string UnsupportedProviderCode = "PROVIDER_UNSUPPORTED";
        public const string UnsupportedProviderMessage = "Provider is unsupported";
    }
}
