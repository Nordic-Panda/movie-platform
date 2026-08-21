using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Languages.GetLanguages
{
    public record GetLanguagesQuery : IRequest<IReadOnlyList<LanguageDto>>;
}
