namespace MovieService.Domain.Actors
{
    public static class ActorErrors
    {
        public const string ActorFirstNameEmptyCode = "ACTOR_FIRST_NAME_EMPTY";
        public const string ActorFirstNameEmptyMessage = "Actor firstname cannot be empty";

        public const string ActorLastNameEmptyCode = "ACTOR_LAST_NAME_EMPTY";
        public const string ActorLastNameEmptyMessage = "Actor lastname cannot be empty";

        public const string ActorBirthYearInvalidCode = "ACTOR_BIRTHYEAR_INVALID";
        public static string ActorBirthYearInvalidMessage(int startingYear, int currentYear)
            => $"Actor birth year must be between {startingYear} and {currentYear}.";
    }
}