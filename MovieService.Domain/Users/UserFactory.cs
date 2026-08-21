using MovieService.Domain.Common.Normalizers;

namespace MovieService.Domain.Users
{
    public static class UserFactory
    {
        public static User Create(string email, string passwordHash, Guid roleId)
        {
            // lack validator

            var normalizedEmail = StringNormalizer.NormalizeName(email);

            return new User(normalizedEmail, passwordHash, roleId);
        }
    }
}
