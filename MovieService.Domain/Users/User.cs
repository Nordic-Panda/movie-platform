namespace MovieService.Domain.Users;

public class User
{
    public Guid Id { get; private set; }

    public string Email { get; private set; } = string.Empty;

    public string Username { get; private set; } = string.Empty;

    public string DisplayName { get; private set; } = string.Empty;

    public Guid RoleId { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public void Disable() => IsActive = false;

    public void Enable() => IsActive = true;

    private User() { }

    internal User(string email, string username, string displayName, Guid roleId)
    {
        Id = Guid.NewGuid();
        Email = email;
        Username = username;
        DisplayName = displayName;
        RoleId = roleId;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }
}
