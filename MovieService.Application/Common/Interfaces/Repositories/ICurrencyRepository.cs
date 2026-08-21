using MovieService.Domain.Currencies;

namespace MovieService.Application.Common.Interfaces.Repositories
{
    public interface ICurrencyRepository
    {
        Task AddAsync(Currency currency);

        Task<IReadOnlyList<Currency>> GetAllCurrenciesAsync();
        Task<IReadOnlyList<Currency>> GetAllActiveCurrenciesAsync();

        Task<Currency?> GetCurrencyByCode(string code);
        Task<Currency?> GetActiveCurrencyByCode(string code);
    }
}
