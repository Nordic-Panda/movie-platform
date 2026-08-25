namespace MovieService.Domain.Users
{
    public static class UserErrors
    {
        public const string InActiveUser = "Inactive User";
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

        public const string DisplayNameEmptyCode = "DISPLAY_NAME_EMPTY";
        public const string DisplayNameEmptyMessage = "Display name can not be empty";

        public const string DisplayNameTooLongCode = "DISPLAY_NAME_TOO_LONG";

        public static string DisplayNameTooLongMessage(int maxLength) =>
            $"Display name can not exceed {maxLength} characters";

        public const string UsernameEmptyCode = "USERNAME_EMPTY";
        public const string UsernameEmptyMessage = "Username can not be empty";

        public const string UsernameTooLongCode = "USERNAME_TOO_LONG";

        public static string UsernameTooLongMessage(int maxLength) =>
            $"Username can not exceed {maxLength} characters";

        public const string EmailExistsCode = "EMAIL_EXISTS";
        public const string EmailExistsMessage = "This email is already linked to an account";

        public const string UsernameExistsCode = "USERNAME_EXISTS";
        public const string UsernameExistsMessage = "This username is already linked to an account";

        public const string AccountAlreadyExistsCode = "ACCOUNT_EXISTS";
        public const string AccountAlreadyExistsMessage =
            "An account with provided info already exists";
    }
}
