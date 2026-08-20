using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Exceptions;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;
using MovieService.Domain.Common.Normalizers;
using MovieService.Domain.Languages;

namespace MovieService.Application.Languages.CreateLanguage
{
    public class CreateLanguageHandler : IRequestHandler<CreateLanguageCommand, LanguageDto>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateLanguageHandler(ILanguageRepository languageRepository, IUnitOfWork unitOfWork)
        {
            _languageRepository = languageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<LanguageDto> Handle(
            CreateLanguageCommand request,
            CancellationToken cancellationToken
        )
        {
            var name = StringNormalizer.ToTitleCase(request.Name);
            var code = StringNormalizer.ToUpper(request.Code);

            var existingLanguage = await _languageRepository.GetByNameAsync(name);

            if (existingLanguage is not null)
            {
                throw new ConflictException(
                    LanguageErrors.LanguageAlreadyExistsCode,
                    LanguageErrors.LanguageAlreadyExistsMessage(name)
                );
            }

            var existingLanguageCode = await _languageRepository.GetByCodeAsync(code);

            if (existingLanguageCode is not null)
            {
                throw new ConflictException(
                    LanguageErrors.LanguageCodeAlreadyExistsCode,
                    LanguageErrors.LanguageCodeAlreadyExistsMessage(code)
                );
            }

            var language = LanguageFactory.Create(name, code);

            await _languageRepository.AddAsync(language);
            await _unitOfWork.SaveChangesAsync();

            return LanguageMapper.ToDto(language);
        }
    }
}
