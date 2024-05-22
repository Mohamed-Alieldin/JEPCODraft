

using JEPCO.Domain.Entities;

namespace JEPCO.Application.Services.WeatherForecast;

public interface IWeatherForecastService
{
    Task<List<WeatherForecastTable>> Get();
    Task<int> CreateNewRow();
}
