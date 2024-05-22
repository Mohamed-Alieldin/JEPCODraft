using JEPCO.Application.Interfaces.Repositories.Base;
using JEPCO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEPCO.Application.Interfaces.Repositories
{
    public interface IWeatherForecastRepo: IRepository<WeatherForecastTable>
    {
        Task<List<WeatherForecastTable>> GetAll();
        Task<int> CreateNew();
    }
}
