using MovieService.Domain.Common.Exceptions;

namespace MovieService.Domain.Users
{
    public static class UserRules
    {
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

        public static void ValidateRoleId(Guid id)
        {
            if (id == Guid.Empty)
                throw new DomainException(
                    UserErrors.RoleIdEmptyCode,
                    UserErrors.RoleIdEmptyMessage
                );
        }
    }
}
