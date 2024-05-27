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
            Random rnd = new Random();
            var addedEntity = await AddAsync(new WeatherForecastTable
            {
                Month = rnd.Next(1, 12),
                Day = rnd.Next(1, 30),
                Year = 2024,
                Summary = "test",
                TemperatureC = 32,
            });
            return addedEntity.Entity;
        }

       public async Task<List<WeatherForecastTable>> GetAllRecords()
        {
            return await GetAllAsync();
        }

        public async Task<WeatherForecastTable> UpdateRow()
        {
            var dm = await GetByIdAsync(7);
            //dm.Summary = "update";
            //dm.TemperatureC = 12;
            dm.IsDeleted = true;

            Update(dm);

            return dm;
        }
    }
}
