

namespace JEPCO.Application.Models.WeatherForecast;

public class WeatherForecastResponse
{
    public int Id { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public int Year { get; set; }

    public int TemperatureC { get; set; }
    public string? Summary { get; set; }
}
