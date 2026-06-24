namespace MovieService.Domain.Actors
{
    public static class ActorErrors
    {
        public const string ActorNameEmptyCode = "ACTOR_NAME_EMPTY";
        public const string ActorNameEmptyMessage = "Actor name cannot be empty";

        public const string ActorBirthYearInvalidCode = "ACTOR_BIRTHYEAR_INVALID";
        public const string ActorBirthYearInvalidMessage = "Actor birth year must be between 1850 and current year";
    }
}