using MovieService.Domain.Common.Exceptions;
using MovieService.Domain.UserIdentities;
using MovieService.Domain.Users;

public static class UserIdentityFactory
{
    public static UserIdentity CreateLocal(Guid userId, string passwordHash)
    {
        UserIdentityRules.ValidateUserId(userId);
        var subject = userId.ToString();
        UserIdentityRules.ValidateIdentitySubject(subject);

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new DomainException(
                UserErrors.PasswordEmptyCode,
                UserErrors.PasswordEmptyMessage
            );

        return new UserIdentity(userId, IdentityProviders.Local, subject, passwordHash);
    }

    public static UserIdentity CreateExternal(Guid userId, string provider, string subject)
    {
        UserIdentityRules.ValidateUserId(userId);
        UserIdentityRules.ValidateIdentityProvider(provider);
        UserIdentityRules.ValidateIdentitySubject(subject);

        return new UserIdentity(userId, provider, subject, null);
    }
}
