using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;

namespace MovieService.Application.Languages.GetLanguages
{
    public class GetLanguagesHandler
        : IRequestHandler<GetLanguagesQuery, IReadOnlyList<LanguageDto>>
    {
        private readonly ILanguageRepository _languageRepository;

        public GetLanguagesHandler(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<IReadOnlyList<LanguageDto>> Handle(
            GetLanguagesQuery request,
            CancellationToken cancellationToken
        )
        {
            var languages = await _languageRepository.GetAllActiveLanguagesAsync();

            return languages.Select(LanguageMapper.ToDto).ToList();
        }
    }
}
