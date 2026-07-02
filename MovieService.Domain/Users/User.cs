namespace MovieService.Domain.Users
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }

        private User() { }

        public User(Guid id, string email, string hashedPass)
        {
            Id = id;
            Email = email;
            PasswordHash = hashedPass;
        }
    }
}
