using MovieService.Domain.Currencies;

namespace MovieService.Application.Common.Interfaces.Repositories
{
    public interface ICurrencyRepository
    {
        Task AddAsync(Currency currency);

        Task<IReadOnlyList<Currency>> GetAllCurrenciesAsync();
        Task<IReadOnlyList<Currency>> GetAllActiveCurrenciesAsync();

        Task<Currency?> GetCurrencyByCodeAsync(string code);
        Task<Currency?> GetActiveCurrencyByCodeAsync(string code);
    }
}
