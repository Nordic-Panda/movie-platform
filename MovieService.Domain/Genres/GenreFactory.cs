using MovieService.Domain.Common.Normalizers;

namespace MovieService.Domain.Genres
{
    public static class GenreFactory
    {
        public static Genre Create(string title)
        {
            GenreRules.ValidateName(title);

            var normalizedName = StringNormalizer.NormalizeName(title);

            GenreRules.ValidateLength(normalizedName);

            return new Genre(normalizedName);
        }
    }
}
