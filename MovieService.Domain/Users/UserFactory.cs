using MovieService.Domain.Common.Normalizers;

namespace MovieService.Domain.Users
{
    public static class UserFactory
    {
        public static User Create(
            string email,
            string username,
            string displayName,
            string passwordHash,
            Guid roleId
        )
        {
            UserRules.ValidateEmail(email);
            var normalizedEmail = StringNormalizer.NormalizeName(email);

            UserRules.ValidateUsername(username);
            var normalizedUsername = StringNormalizer.NormalizeName(username);
            UserRules.ValidateUsernameLength(normalizedUsername);

            UserRules.ValidateDisplayName(displayName);
            var normalizedDisplayName = StringNormalizer.NormalizeName(displayName);
            UserRules.ValidateDisplayNameLength(normalizedDisplayName);

            UserRules.ValidatePassword(passwordHash);

            UserRules.ValidateRoleId(roleId);

            return new User(
                normalizedEmail,
                normalizedUsername,
                normalizedDisplayName,
                passwordHash,
                roleId
            );
        }
    }
}
