namespace MovieService.Domain.Genres
{
    public static class GenreErrors
    {
        public const string OneOrMoreGenresNotFoundCode = "GENRE_NOT_FOUND";
        public const string OneOrMoreGenresNotFoundMessage = "One or more genres not found.";

        public const string GenreNameEmptyCode = "GENRE_NAME_EMPTY";
        public const string GenreNameEmptyMessage = "Genre name cannot be empty.";

        public const string GenreNameTooLongCode = "GENRE_NAME_TOO_LONG";
        public const string GenreNameTooLongMessage = "Genre name cannot exceed 100 characters.";

        public const string GenreNameAlreadyExistsCode = "GENRE_NAME_ALREADY_EXISTS";
        public const string GenreNameAlreadyExistsMessage = "Genre name already exists.";
    }
}
