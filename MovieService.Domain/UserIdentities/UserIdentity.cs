namespace MovieService.Domain.UserIdentities
{
    public class UserIdentity
    {
        public Guid Id { get; private set; }

        // One user can have multiple identities
        public Guid UserId { get; private set; }

        // Who provided the identity, for example Microsoft, Google
        public string Provider { get; private set; }

        // The identifier, who does the token represent
        public string Subject { get; private set; }

        public string? PasswordHash { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private UserIdentity() { }

        internal UserIdentity(Guid userId, string provider, string subject, string? passwordHash)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Provider = provider;
            Subject = subject;
            PasswordHash = passwordHash;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
