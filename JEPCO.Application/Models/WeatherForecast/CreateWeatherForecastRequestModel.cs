using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEPCO.Application.Models.WeatherForecast
{
    public class CreateWeatherForecastRequestModel
    {
        [Required]
        [Range(1,200,ErrorMessage = "Temp must be more than 1")]
        public int? Temperature { get; set; }
    }
}
