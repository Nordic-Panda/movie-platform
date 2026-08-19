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

        public async Task<Language> AddAsync(Language language)
        {
            await _appDbContext.Languages.AddAsync(language);
            return language;
        }

        public async Task<IReadOnlyList<Language>> GetAllLanguagesAsync()
        {
            return await _appDbContext.Languages.AsNoTracking().ToListAsync();
        }

        // SInce there is AsNoTracking, update can not use this, needs a seperate method to get the entity for update
        public async Task<Language?> GetByIdAsync(Guid id)
        {
            return await _appDbContext
                .Languages.AsNoTracking()
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Language?> GetByNameAsync(string name)
        {
            return await _appDbContext
                .Languages.AsNoTracking()
                .FirstOrDefaultAsync(l => l.Name == name);
        }
    }
}
