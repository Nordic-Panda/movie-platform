using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Languages;

namespace MovieService.Application.Languages.GetLanguageById
{
    public class GetLanguageByIdHandler : IRequestHandler<GetLanguageByIdQuery, LanguageDto>
    {
        private readonly ILanguageRepository _languageRepository;

        public GetLanguageByIdHandler(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<LanguageDto> Handle(
            GetLanguageByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var existingLanguage = await _languageRepository.GetActiveLanguageByIdAsync(request.Id);

            return existingLanguage is null
                ? throw new NotFoundException(
                    LanguageErrors.LanguageNotFoundCode,
                    LanguageErrors.LanguageNotFoundMessage
                )
                : LanguageMapper.ToDto(existingLanguage);
        }
    }
}
