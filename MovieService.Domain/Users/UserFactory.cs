namespace MovieService.Domain.Users
{
    public static class UserFactory
    {
        public static User Create(string email, string passwordHash, Guid roleId)
        {
            // lack validator
        }
    }
}
