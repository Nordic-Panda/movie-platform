using MovieService.Domain.Common.Exceptions;

namespace MovieService.Domain.Genres
{
    public static class GenreFactory
    {
        public static Genre Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException(
                    GenreErrors.GenreNameEmptyCode,
                    GenreErrors.GenreNameEmptyMessage);
            return new Genre(Guid.NewGuid(), name.Trim());
        }
    }
}
