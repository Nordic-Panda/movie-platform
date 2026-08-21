using MovieService.Domain.Common.Exceptions;

namespace MovieService.Domain.Roles
{
    public static class RoleRules
    {
        public const int NameMaxLength = 50;
        public const int CodeMaxLength = 50;

        public static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException(RoleErrors.NameEmptyCode, RoleErrors.NameEmptyMessage);
        }

        public static void ValidateNameLength(string name)
        {
            if (name.Length > NameMaxLength)
                throw new DomainException(
                    RoleErrors.NameTooLongCode,
                    RoleErrors.NameTooLongMessage(NameMaxLength)
                );
        }

        public static void ValidateCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new DomainException(RoleErrors.CodeEmptyCode, RoleErrors.CodeEmptyMessage);
        }

        public static void ValidateCodeLength(string code)
        {
            if (code.Length > CodeMaxLength)
                throw new DomainException(
                    RoleErrors.CodeTooLongCode,
                    RoleErrors.CodeTooLongMessage(CodeMaxLength)
                );
        }
    }
}
