using MovieService.Domain.Common.Enums;

namespace MovieService.Domain.Users
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public UserRole Role { get; private set; }

        private User() { }

        public User(Guid id, string email, string hashedPass, UserRole role)
        {
            Id = id;
            Email = email;
            PasswordHash = hashedPass;
            Role = role;
        }
    }
}
