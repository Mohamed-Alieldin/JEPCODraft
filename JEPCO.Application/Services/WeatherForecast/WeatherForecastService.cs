

using JEPCO.Application.Interfaces.UnitOfWork;
using JEPCO.Domain.Entities;

namespace JEPCO.Application.Services.WeatherForecast
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IUnitOfWork unitOfWork;
        public WeatherForecastService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<WeatherForecastTable>> Get()
        {
            var res = await unitOfWork.WeatherForecastRepo.GetAll();
            return res;
        }

        public async Task<int> CreateNewRow()
        {
            var res = await unitOfWork.WeatherForecastRepo.CreateNew();
            await unitOfWork.CompleteAsync();
            return res;
        }
    }
}
