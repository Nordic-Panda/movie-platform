using MovieService.Domain.Languages;

namespace MovieService.Application.Common.Interfaces.Repositories
{
    public interface ILanguageRepository
    {
        Task<IReadOnlyList<Language>> GetAllLanguagesAsync();
        Task<Language?> GetByIdAsync(Guid id);
        Task<Language?> GetByNameAsync(string name);
        Task<Language?> GetByCodeAsync(string code);
        Task<Language> AddAsync(Language language);
    }
}
