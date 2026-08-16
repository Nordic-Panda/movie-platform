namespace MovieService.Domain.Genres
{
    public static class GenreErrors
    {
        public const string OneOrMoreGenresNotFoundCode = "GENRE_NOT_FOUND";
        public const string OneOrMoreGenresNotFoundMessage = "One or more genres not found.";

        public const string GenreNameEmptyCode = "GENRE_NAME_EMPTY";
        public const string GenreNameEmptyMessage = "Genre name cannot be empty.";
    }
}
