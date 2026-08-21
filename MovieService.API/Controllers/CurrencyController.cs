using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieService.API.Common.Contracts;
using MovieService.Application.Common.DTOs;
using MovieService.Application.Currencies.GetCurrencies;

namespace MovieService.API.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CurrencyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCurrencies()
        {
            var result = await _mediator.Send(new GetCurrenciesQuery());

            return Ok(ApiResponse<IReadOnlyList<CurrencyDto>>.Ok(result));
        }
    }
}
