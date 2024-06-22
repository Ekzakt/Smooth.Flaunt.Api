namespace Smooth.Flaunt.Api.Application.WeatherForecasts;

public interface IWeatherForecastService
{
    Task<List<WeatherForecast>?> GetAllAsync(int? number, CancellationToken cancellationToken);
}