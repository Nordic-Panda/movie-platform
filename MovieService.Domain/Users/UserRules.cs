using MovieService.Domain.Common.Exceptions;

namespace MovieService.Domain.Users
{
    public static class UserRules
    {
        public const int DisplayNameMaxLenth = 50;
        public const int UsernameMaxLength = 30;

        public static void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new DomainException(UserErrors.EmailEmptyCode, UserErrors.EmailEmptyMessage);
        }

        public static void ValidatePassword(string pass)
        {
            if (string.IsNullOrWhiteSpace(pass))
                throw new DomainException(
                    UserErrors.PasswordEmptyCode,
                    UserErrors.PasswordEmptyMessage
                );
        }

        public static void ValidateDisplayName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException(
                    UserErrors.DisplayNameEmptyCode,
                    UserErrors.DisplayNameEmptyMessage
                );
        }

        public static void ValidateUsername(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException(
                    UserErrors.UsernameEmptyCode,
                    UserErrors.UsernameEmptyMessage
                );
        }

        public static void ValidateRoleId(Guid id)
        {
            if (id == Guid.Empty)
                throw new DomainException(
                    UserErrors.RoleIdEmptyCode,
                    UserErrors.RoleIdEmptyMessage
                );
        }

        public static void ValidateDisplayNameLength(string name)
        {
            if (name.Length > DisplayNameMaxLenth)
                throw new DomainException(
                    UserErrors.DisplayNameTooLongCode,
                    UserErrors.DisplayNameTooLongMessage(DisplayNameMaxLenth)
                );
        }

        public static void ValidateUsernameLength(string name)
        {
            if (name.Length > UsernameMaxLength)
                throw new DomainException(
                    UserErrors.UsernameTooLongCode,
                    UserErrors.UsernameTooLongMessage(UsernameMaxLength)
                );
        }
    }
}
