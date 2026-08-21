using MovieService.Domain.Common.Exceptions;

namespace MovieService.Domain.Genres
{
    public static class GenreRules
    {
        public const int NameMaxLength = 100;

        public static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException(
                    GenreErrors.GenreNameEmptyCode,
                    GenreErrors.GenreNameEmptyMessage
                );
        }

        public static void ValidateLength(string name)
        {
            if (name.Length > NameMaxLength)
                throw new DomainException(
                    GenreErrors.GenreNameTooLongCode,
                    GenreErrors.GenreNameTooLongMessage(NameMaxLength)
                );
        }
    }
}
