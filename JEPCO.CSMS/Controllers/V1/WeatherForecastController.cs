
using Microsoft.AspNetCore.Mvc;
using JEPCO.Application.Services.WeatherForecast;
using JEPCO.Application.Models.WeatherForecast;
using JEPCO.Application.Exceptions;

namespace JEPCO.CSMS.Controllers.V1
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherForecastAppService weatherForecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherForecastAppService weatherForecastService)
        {
            _logger = logger;
            this.weatherForecastService = weatherForecastService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            var data = await weatherForecastService.Get();
            return Ok(data);
        }

        [HttpPost(Name = "add")]
        public async Task<IActionResult> Post([FromBody] CreateWeatherForecastRequestModel model)
        {
            var res = await weatherForecastService.CreateNewRow(model);
            return Ok(res);
        }
    }
}
