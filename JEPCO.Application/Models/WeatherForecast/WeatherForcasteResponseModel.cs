

namespace JEPCO.Application.Models.WeatherForecast;

public class WeatherForcasteResponseModel
{
    public IEnumerable<WeatherForecastResponse> result { get; set; }
    public string Message { get; set; }
}
