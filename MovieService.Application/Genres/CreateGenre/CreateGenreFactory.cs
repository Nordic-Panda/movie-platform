using MovieService.Domain.Common.Normalizers;
using MovieService.Domain.Genres;

namespace MovieService.Application.Genres.CreateGenre
{
    public static class CreateGenreFactory
    {
        public static Genre Create(CreateGenreCommand command)
        {
            GenreRules.ValidateName(command.Name);
            var normalizedName = StringNormalizer.NormalizeName(command.Name);
            GenreRules.ValidateLength(normalizedName);

            return GenreFactory.Create(normalizedName);
        }
    }
}
