using MovieService.Domain.Common.Normalizers;

namespace MovieService.Domain.Roles
{
    public static class RoleFactory
    {
        public static Role Create(string name, string code)
        {
            RoleRules.ValidateName(name);
            RoleRules.ValidateCode(code);

            var normalizedName = StringNormalizer.NormalizeName(name);
            var normalizedCode = StringNormalizer.ToUpper(code);

            RoleRules.ValidateNameLength(normalizedName);
            RoleRules.ValidateCodeLength(normalizedCode);

            return new Role(normalizedName, normalizedCode);
        }
    }
}
