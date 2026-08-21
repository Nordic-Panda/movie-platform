public class User
{
    public Guid Id { get; private set; }
    public string Email { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;

    public Guid RoleId { get; private set; }
    public bool IsActive { get; private set; }

    public void Disable() => IsActive = false;

    public void Enable() => IsActive = true;

    private User() { }

    internal User(string email, string passwordHash, Guid roleId)
    {
        Id = Guid.NewGuid();
        Email = email;
        PasswordHash = passwordHash;
        RoleId = roleId;
        IsActive = true;
    }
}
