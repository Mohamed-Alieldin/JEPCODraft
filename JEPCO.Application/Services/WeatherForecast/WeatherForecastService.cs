using AutoMapper;
using JEPCO.Application.Interfaces.UnitOfWork;
using JEPCO.Application.Models.WeatherForecast;
using JEPCO.Shared;
using JEPCO.Shared.Constants;
using Microsoft.Extensions.Localization;

namespace JEPCO.Application.Services.WeatherForecast
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IStringLocalizer<SharedResource> localizer;
        public WeatherForecastService(IUnitOfWork unitOfWork, IStringLocalizer<SharedResource> localizer, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.localizer = localizer;
            this.mapper = mapper;
        }

        public async Task<WeatherForcasteResponseModel> Get()
        {
            var data = await unitOfWork.WeatherForecastRepo.GetAllRecords();
            var res = data.Select(mapper.Map<WeatherForecastResponse>);

            return new WeatherForcasteResponseModel()
            {
                result = res,
                Message = localizer.GetString(LocalizationKeysConstant.DataRetrieved)
            };
        }

        public async Task<WeatherForecastResponse> CreateNewRow()
        {
            var added = await unitOfWork.WeatherForecastRepo.CreateNew();
            await unitOfWork.CompleteAsync();
            var res = mapper.Map<WeatherForecastResponse>(added);
            return res;
        }
    }
}
