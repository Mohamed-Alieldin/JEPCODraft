using JEPCO.Domain.Common;


namespace JEPCO.Domain.Entities;

public class WeatherForecastTable: AuditableWithBaseEntity<int>, IAuditLoggableEntity
{
    public int Month { get; set; }
    public int Day { get; set; }
    public int Year { get; set; }

    public int TemperatureC { get; set; }
    public string? Summary { get; set; }
}
