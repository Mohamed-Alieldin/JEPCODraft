

namespace JEPCO.Application.Services.WeatherForecast;

public interface IWeatherForecastService
{
    IEnumerable<Models.WeatherForecast.WeatherForecast> Get();
}
