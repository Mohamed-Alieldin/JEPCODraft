﻿using JEPCO.Application.Services.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JEPCO.Application.Services.WeatherForecast;
using System.Reflection;

namespace JEPCO.Application.Extensions;

public static class StartupExtension
{
    private static IServiceCollection _services { get; set; }

    public static void RegisterApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        _services = services;
        //services.AddAutoMapper(Assembly.GetExecutingAssembly());

        _services.AddScoped<IUserService,UserService>();
        _services.AddScoped<IWeatherForecastService, WeatherForecastService>();

    }
}
