using MovieService.Domain.Common.Exceptions;

namespace MovieService.Domain.UserIdentities
{
    public static class UserIdentityRules
    {
        public const int UserIdentityProviderMaxLength = 50;
        public const int UserIdentitySubjectMaxLength = 200;

        public static void ValidateIdentityProvider(string provider)
        {
            if (string.IsNullOrWhiteSpace(provider))
                throw new DomainException(
                    UserIdentityErrors.IdentityProviderEmptyCode,
                    UserIdentityErrors.IdentityProviderEmptyMessage
                );
        }

        public static void ValidateIdentitySubject(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
                throw new DomainException(
                    UserIdentityErrors.IdentitySubjectEmptyCode,
                    UserIdentityErrors.IdentitySubjectEmptyMessage
                );
        }

        public static void ValidateUserId(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new DomainException(
                    UserIdentityErrors.UserIdEmptyCode,
                    UserIdentityErrors.UserIdEmptyMessage
                );
        }
    }
}
