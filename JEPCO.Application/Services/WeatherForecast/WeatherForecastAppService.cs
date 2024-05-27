using AutoMapper;
using JEPCO.Application.Interfaces.UnitOfWork;
using JEPCO.Application.Models.WeatherForecast;
using JEPCO.Shared;
using JEPCO.Shared.Constants;
using JEPCO.Shared.ModelsAbstractions;
using JEPCO.Shared.ResponsesAbstractions;
using Microsoft.AspNetCore.Http;
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

        public async Task<QueryResult<WeatherForecastResponse>> Get()
        {
            var data = await unitOfWork.WeatherForecastRepo.GetAllRecords();
            var res = data.Select(mapper.Map<WeatherForecastResponse>);

            var querydata = new QueryResultData<WeatherForecastResponse>()
            {
                Count = data.Count,
                Rows = res
            };

            return new QueryResult<WeatherForecastResponse>(querydata, localizer.GetString(LocalizationKeysConstant.DataRetrieved));
        }

        public async Task<Response<WeatherForecastResponse>> CreateNewRow()
        {
            var added = await unitOfWork.WeatherForecastRepo.CreateNew();
            //var added = await unitOfWork.WeatherForecastRepo.UpdateRow();
            await unitOfWork.CompleteAsync();
            var res = mapper.Map<WeatherForecastResponse>(added);
            return new (res, SuccessResponseEnum.Created, localizer.GetString(LocalizationKeysConstant.ResourceCreated));
        }
    }
}
