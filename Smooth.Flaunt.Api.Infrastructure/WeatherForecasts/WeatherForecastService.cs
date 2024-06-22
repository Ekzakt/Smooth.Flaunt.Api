using Microsoft.Extensions.Logging;
using Smooth.Flaunt.Api.Application.WeatherForecasts;

namespace Smooth.Flaunt.Api.Infrastructure.WeatherForecasts;

public class WeatherForecastService
    : IWeatherForecastService
{
    private readonly ILogger<WeatherForecastService> _logger;

    public WeatherForecastService(ILogger<WeatherForecastService> logger)
    {
        _logger = logger;
    }


    public async Task<List<WeatherForecast>?> GetAllAsync(int? rowCount, CancellationToken cancellationToken)
    {
        var randomNumber = new Random();
        var temp = 0;

        try
        {
            var output = await Task.Run(() =>
            {
                var result = Enumerable.Range(1, CheckRowcount(rowCount)).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = temp = randomNumber.Next(-20, 55),
                    Summary = GetSummary(temp)
                }).ToList();

                return result;

            }, cancellationToken);

            return output;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
        
    }


    #region Helpers

    private string GetSummary(int temp)
    {
        var summary = "Mild";
        if (temp >= 32)
        {
            summary = "Hot";
        }
        else if (temp <= 16 && temp > 0)
        {
            summary = "Cold";
        }
        else if (temp <= 0)
        {
            summary = "Freezing";
        }
        return summary;
    }

    private int CheckRowcount(int? rowCount)
    {
        var output = rowCount.GetValueOrDefault(10);

        output = output <= 1 ? 10 : output;

        return output;
    }

    #endregion Helpers
}
