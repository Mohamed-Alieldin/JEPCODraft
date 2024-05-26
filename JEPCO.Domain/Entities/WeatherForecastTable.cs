using JEPCO.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEPCO.Domain.Entities
{
    public class WeatherForecastTable: AuditableWithBaseEntity<int>
    {
        public int Month { get; set; }
        public int Day { get; set; }
        public int Year { get; set; }

        public int TemperatureC { get; set; }
        public string? Summary { get; set; }
    }
}
