
using Microsoft.AspNetCore.Mvc;
using JEPCO.Application.Services.WeatherForecast;
using JEPCO.Application.Models.WeatherForecast;
using JEPCO.Application.Exceptions;
using JEPCO.Shared.ResponsesAbstractions;
using JEPCO.Shared.ModelsAbstractions;

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
        [ProducesResponseType(typeof(QueryResult<WeatherForecastResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get()
        {
            var data = await weatherForecastService.Get();
            return Ok(data);
        }

        [HttpPost(Name = "add")]
        [ProducesResponseType(typeof(Response<WeatherForecastResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post()
        {
            var res = await weatherForecastService.CreateNewRow();
            return Ok(res);
        }
    }
}
