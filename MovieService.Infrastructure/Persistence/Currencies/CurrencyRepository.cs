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

        public async Task<IReadOnlyList<Currency>> GetCurrenciesAsync()
        {
            return await _context.Currencies.AsNoTracking().ToListAsync();
        }

        public async Task<Currency?> GetCurrencyByCode(string code)
        {
            return await _context.Currencies.FirstOrDefaultAsync(c => c.Code == code);
        }
    }
}
