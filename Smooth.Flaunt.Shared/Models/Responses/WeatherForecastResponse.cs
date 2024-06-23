using Smooth.Flaunt.Shared.Models;
using Smooth.Flaunt.Shared.Models.Dtos;

namespace Smooth.Flaunt.Shared.Models.Responses;

public class WeatherForecastResponse
{
    public List<WeatherForecastDto> WeatherForecasts { get; set; } = new();
}
