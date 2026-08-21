namespace MovieService.Domain.Users
{
    public class UserErrors
    {
        public const string NotFoundCode = "USER_NOT_FOUND";
        public const string NotFoundMessage = "User not found";

        public const string CredentialInvalidCode = "CREDENTIAL_INVALID";
        public const string CredentialInvalidMessage = "Wrong email or password";

        public const string AccountNotAvailableCode = "ACCOUNT_NOT_AVAILABLE";
        public const string AccountNotAvailableMessage = "Account is currently unavailable";
    }
}
