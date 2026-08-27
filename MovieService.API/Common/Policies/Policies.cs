namespace MovieService.API.Common.Policy
{
    public class Policies
    {
        public const string MovieCreate = "Movie.Create";
        public const string MovieDelete = "Movie.Delete";
        public const string AdminOnly = "AdminOnly";

        public const string AuthenticatedUser = "Authenticated Users";
    }
}
