using JEPCO.Application.Models.WeatherForecast;
using JEPCO.Shared;
using JEPCO.Shared.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using JEPCO.Application.Services.WeatherForecast;

namespace JEPCO.CSMS.Controllers.V1
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly IWeatherForecastService weatherForecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IStringLocalizer<SharedResource> localizer, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _localizer = localizer;
            this.weatherForecastService = weatherForecastService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public WeatherForcasteResponseModel Get()
        {

            var data = weatherForecastService.Get();

            return new WeatherForcasteResponseModel()
            {
                result = data,
                Message = _localizer.GetString(LocalizationKeysConstant.DataRetrieved)
            };
        }
    }
}
