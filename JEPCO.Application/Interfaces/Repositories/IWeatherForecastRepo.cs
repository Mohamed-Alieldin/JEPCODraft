using JEPCO.Application.Interfaces.Repositories.Base;
using JEPCO.Application.Models.WeatherForecast;
using JEPCO.Domain.Entities;

namespace JEPCO.Application.Interfaces.Repositories
{
    public interface IWeatherForecastRepo: IRepository<WeatherForecastTable>
    {
        Task<List<WeatherForecastTable>> GetAllRecords();
        Task<WeatherForecastTable> CreateNew();
    }
}
