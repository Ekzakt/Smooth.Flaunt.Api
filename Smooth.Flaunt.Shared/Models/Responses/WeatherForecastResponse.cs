using Smooth.Flaunt.Shared.Models;

namespace Smooth.Flaunt.Shared.Models.Responses;

public class WeatherForecastResponse
{
    public List<WeatherForecastDto> WeatherForecasts { get; set; } = new();
}
