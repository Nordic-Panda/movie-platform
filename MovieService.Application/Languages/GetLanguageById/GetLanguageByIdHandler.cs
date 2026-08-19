using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;

namespace MovieService.Application.Languages.GetLanguageById
{
    public class GetLanguageByIdHandler : IRequestHandler<GetLanguageByIdQuery, LanguageDto?>
    {
        private readonly ILanguageRepository _languageRepository;

        public GetLanguageByIdHandler(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<LanguageDto?> Handle(
            GetLanguageByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var language = await _languageRepository.GetByIdAsync(request.Id);

            return language is null ? null : LanguageMapper.ToDto(language);
        }
    }
}
