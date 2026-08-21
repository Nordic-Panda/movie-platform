namespace MovieService.Domain.Users
{
    public static class UserErrors
    {
        public const string NotFoundCode = "USER_NOT_FOUND";
        public const string NotFoundMessage = "User not found";

        public const string CredentialInvalidCode = "CREDENTIAL_INVALID";
        public const string CredentialInvalidMessage = "Wrong email or password";

        public const string AccountNotAvailableCode = "ACCOUNT_NOT_AVAILABLE";
        public const string AccountNotAvailableMessage = "Account is currently unavailable";

        public const string EmailEmptyCode = "EMAIL_EMPTY";
        public const string EmailEmptyMessage = "Email is empty";

        public const string PasswordEmptyCode = "PASSWORD_EMPTY";
        public const string PasswordEmptyMessage = "Password is empty";

        public const string RoleIdEmptyCode = "ROLE_ID_EMPTY";
        public const string RoleIdEmptyMessage = "Role is empty";
    }
}
