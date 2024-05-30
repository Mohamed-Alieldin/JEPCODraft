using JEPCO.Application.Services.Reseller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JEPCO.CSMS.Controllers.V1;

[ApiController]
[Route("v1/reseller")]
//[Authorize]
public class ResellerController : ControllerBase
{
    private readonly ILogger<ResellerController> _logger;
    private readonly ResellerAppService _resellerService;

    public ResellerController(ILogger<ResellerController> logger, ResellerAppService resellerService)
    {
        _logger = logger;
        _resellerService = resellerService;
    }


    [HttpGet]
    //[ProducesResponseType(typeof(QueryResult<WeatherForecastResponse>), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Get([FromQuery] Guid Id)
    {
        return Ok();
    }
}
