using AutoMapper;
using JEPCO.Application.Models.WeatherForecast;
using JEPCO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEPCO.Application.Mapper
{
    public class WeatherForecastMapper : Profile
    {
        public WeatherForecastMapper()
        {
            CreateMap<WeatherForecastTable, WeatherForecastResponse>();
        }
    }
}
