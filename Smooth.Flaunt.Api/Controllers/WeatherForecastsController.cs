using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smooth.Flaunt.Api.Application.WeatherForecasts;
using Smooth.Flaunt.Shared.Endpoints;

namespace Smooth.Flaunt.Api.Controllers
{
    [ApiController]
    [Route(Ctrls.WEATERFORECASTS)]
    [AllowAnonymous]
    public class WeatherForecastsController(
        IWeatherForecastService _weatherForecastService)
        : ControllerBase
    {

        [HttpGet]
        [Route(Routes.GET_WEATERFORECASTS)]
        public async Task<IActionResult> GetByRowcount(int? r, CancellationToken cancellationToken)
        {
            var result = await _weatherForecastService.GetAllAsync(r, cancellationToken);

            return result is not null
                ? Ok(result)
                : NoContent();
        }
    }
}
