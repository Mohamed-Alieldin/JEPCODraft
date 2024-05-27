﻿using AutoMapper;
using JEPCO.Application.Interfaces.UnitOfWork;
using JEPCO.Application.Models.WeatherForecast;
using JEPCO.Shared;
using JEPCO.Shared.Constants;
using Microsoft.Extensions.Localization;

namespace JEPCO.Application.Services.WeatherForecast
{
    public class WeatherForecastAppService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IStringLocalizer<SharedResource> localizer;
        public WeatherForecastAppService(IUnitOfWork unitOfWork, IStringLocalizer<SharedResource> localizer, IMapper mapper)
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

        public async Task<WeatherForecastResponse> CreateNewRow(CreateWeatherForecastRequestModel model)
        {
            var added = await unitOfWork.WeatherForecastRepo.CreateNew((int)model.Temperature!);
            await unitOfWork.CompleteAsync();
            var res = mapper.Map<WeatherForecastResponse>(added);
            return res;
        }
    }
}
