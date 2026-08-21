using MovieService.Domain.Languages;

namespace MovieService.Application.Common.Interfaces.Repositories
{
    public interface ILanguageRepository
    {
        Task AddAsync(Language language);

        Task<IReadOnlyList<Language>> GetAllLanguagesAsync();
        Task<IReadOnlyList<Language>> GetAllActiveLanguagesAsync();

        Task<Language?> GetLanguageByIdAsync(Guid id);
        Task<Language?> GetActiveLanguageByIdAsync(Guid id);

        Task<Language?> GetLanguageByNameAsync(string name);
        Task<Language?> GetActiveLanguageByNameAsync(string name);

        Task<Language?> GetLanguageByCodeAsync(string code);
        Task<Language?> GetActiveLanguageByCodeAsync(string code);
    }
}
