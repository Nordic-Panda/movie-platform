using Microsoft.EntityFrameworkCore;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Domain.Currencies;
using MovieService.Infrastructure.Data;

namespace MovieService.Infrastructure.Persistence.Currencies
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly AppDbContext _context;

        public CurrencyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Currency currency)
        {
            await _context.Currencies.AddAsync(currency);
        }

        public async Task<IReadOnlyList<Currency>> GetAllCurrenciesAsync()
        {
            return await _context.Currencies.AsNoTracking().ToListAsync();
        }

        public async Task<IReadOnlyList<Currency>> GetAllActiveCurrenciesAsync()
        {
            return await _context.Currencies.Where(c => c.IsActive).AsNoTracking().ToListAsync();
        }

        public async Task<Currency?> GetCurrencyByCodeAsync(string code)
        {
            return await _context.Currencies.FirstOrDefaultAsync(c => c.Code == code);
        }

        public async Task<Currency?> GetActiveCurrencyByCodeAsync(string code)
        {
            return await _context.Currencies.FirstOrDefaultAsync(c => c.Code == code && c.IsActive);
        }
    }
}
