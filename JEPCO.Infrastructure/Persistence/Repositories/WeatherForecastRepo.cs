using JEPCO.Application.Interfaces.Repositories;
using JEPCO.Application.Interfaces.Repositories.Base;
using JEPCO.Application.Models.WeatherForecast;
using JEPCO.Domain.Entities;
using JEPCO.Infrastructure.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEPCO.Infrastructure.Persistence.Repository
{
    public class WeatherForecastRepo : Repository<WeatherForecastTable>, IWeatherForecastRepo
    {
        public WeatherForecastRepo(ApplicationDbContext context) : base(context) { }
        public async Task<WeatherForecastTable> CreateNew()
        {
            var addedEntity = await AddAsync(new WeatherForecastTable
            {
                Date = DateTime.UtcNow,
                Summary = "test",
                TemperatureC = 32,
            });
            return addedEntity.Entity;
        }

       public async Task<List<WeatherForecastTable>> GetAllRecords()
        {
            return await GetAllAsync();
        }
    }
}
