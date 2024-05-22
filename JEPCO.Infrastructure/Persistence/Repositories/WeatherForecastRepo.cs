using JEPCO.Application.Interfaces.Repositories;
using JEPCO.Application.Interfaces.Repositories.Base;
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
        public async Task<int> CreateNew()
        {
            var res = await context.WeatherForecastTableSet.AddAsync(new WeatherForecastTable
            {
                Date = DateOnly.MinValue,
                Summary = "test",
                TemperatureC = 32,
            });
            return res.Entity.Id;
        }

       public Task<List<WeatherForecastTable>> GetAll()
        {
            return context.WeatherForecastTableSet.ToListAsync();
        }
    }
}
