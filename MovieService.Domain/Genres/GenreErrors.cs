namespace MovieService.Domain.Genres
{
    public static class GenreErrors
    {
        public const string GenresNotFoundCode = "GENRE_NOT_FOUND";
        public const string GenresNotFoundMessage = "Genre not found.";

        public const string GenreNameEmptyCode = "GENRE_NAME_EMPTY";
        public const string GenreNameEmptyMessage = "Genre name cannot be empty.";

        public const string GenreNameTooLongCode = "GENRE_NAME_TOO_LONG";
        public static string GenreNameTooLongMessage(int maxLength)
            => $"Genre name cannot exceed {maxLength} characters.";

        public const string GenreNameAlreadyExistsCode = "GENRE_NAME_ALREADY_EXISTS";
        public const string GenreNameAlreadyExistsMessage = "Genre name already exists.";
    }
}
