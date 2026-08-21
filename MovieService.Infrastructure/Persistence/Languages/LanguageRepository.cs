using Microsoft.EntityFrameworkCore;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Domain.Languages;
using MovieService.Infrastructure.Data;

namespace MovieService.Infrastructure.Persistence.Languages
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly AppDbContext _appDbContext;

        public LanguageRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Language language)
        {
            await _appDbContext.Languages.AddAsync(language);
        }

        public async Task<IReadOnlyList<Language>> GetAllLanguagesAsync()
        {
            return await _appDbContext.Languages.AsNoTracking().ToListAsync();
        }

        public async Task<IReadOnlyList<Language>> GetAllActiveLanguagesAsync()
        {
            return await _appDbContext
                .Languages.Where(l => l.IsActive)
                .AsNoTracking()
                .ToListAsync();
        }

        // when the Language entity may need to be updated, don't add AsNoTracking.
        // This query is tracked by EF Core.
        public async Task<Language?> GetLanguageByIdAsync(Guid id)
        {
            return await _appDbContext.Languages.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Language?> GetActiveLanguageByIdAsync(Guid id)
        {
            return await _appDbContext.Languages.FirstOrDefaultAsync(l => l.Id == id && l.IsActive);
        }

        // No IsActive check here because when creating a Language,
        // we need to detect duplicates even if the existing Language is inactive.
        public async Task<Language?> GetLanguageByNameAsync(string name)
        {
            return await _appDbContext.Languages.FirstOrDefaultAsync(l => l.Name == name);
        }

        public async Task<Language?> GetActiveLanguageByNameAsync(string name)
        {
            return await _appDbContext.Languages.FirstOrDefaultAsync(l =>
                l.Name == name && l.IsActive
            );
        }

        public async Task<Language?> GetLanguageByCodeAsync(string code)
        {
            return await _appDbContext.Languages.FirstOrDefaultAsync(l => l.Code == code);
        }

        public async Task<Language?> GetActiveLanguageByCodeAsync(string code)
        {
            return await _appDbContext.Languages.FirstOrDefaultAsync(l =>
                l.Code == code && l.IsActive
            );
        }
    }
}
