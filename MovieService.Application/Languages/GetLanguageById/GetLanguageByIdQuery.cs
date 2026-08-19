using MediatR;
using MovieService.Application.Common.DTOs;

namespace MovieService.Application.Languages.GetLanguageById
{
    public record GetLanguageByIdQuery(Guid Id) : IRequest<LanguageDto?>;
}
