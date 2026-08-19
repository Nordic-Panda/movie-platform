using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Languages.CreateLanguage
{
    public record CreateLanguageCommand(string Name, string Code) : IRequest<LanguageDto>;
}
