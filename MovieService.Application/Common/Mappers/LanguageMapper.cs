using MovieService.Application.Common.DTOs;
using MovieService.Domain.Languages;

namespace MovieService.Application.Common.Mappers
{
    public static class LanguageMapper
    {
        public static LanguageDto ToDto(Language language)
        {
            return new LanguageDto(language.Id, language.Name, language.Code);
        }
    }
}
