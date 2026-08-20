using MovieService.Domain.Currencies;

namespace MovieService.Application.Common.Interfaces.Repositories
{
    public interface ICurrencyRepository
    {
        Task<IReadOnlyList<Currency>> GetCurrenciesAsync();
        Task<Currency?> GetCurrencyByCode(string code);
    }
}
