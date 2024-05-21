
namespace JEPCO.Shared.Models.WeatherForecast;

public class WeatherForcasteResponseModel
{
    public IEnumerable<WeatherForecast> result { get; set; }
    public string Message { get; set; }
}
