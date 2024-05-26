

using JEPCO.Application.Models.WeatherForecast;
using JEPCO.Domain.Entities;

namespace JEPCO.Application.Services.WeatherForecast;

public interface IWeatherForecastService
{
    Task<WeatherForcasteResponseModel> Get();
    Task<WeatherForecastResponse> CreateNewRow();
}
