using MediatR;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Common.Interfaces.Repositories;
using MovieService.Application.Common.Mappers;

namespace MovieService.Application.Currencies.GetCurrencies
{
    public class GetCurrenciesHandler
        : IRequestHandler<GetCurrenciesQuery, IReadOnlyList<CurrencyDto>>
    {
        private readonly ICurrencyRepository _currencyRepository;

        public GetCurrenciesHandler(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public async Task<IReadOnlyList<CurrencyDto>> Handle(
            GetCurrenciesQuery request,
            CancellationToken cancellationToken
        )
        {
            var currencies = await _currencyRepository.GetCurrenciesAsync();

            return currencies.Select(CurrencyMapper.ToDto).ToList();
        }
    }
}
