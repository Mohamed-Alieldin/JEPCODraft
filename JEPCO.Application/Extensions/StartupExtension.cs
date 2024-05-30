﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JEPCO.Application.Services.Reseller;

namespace JEPCO.Application.Extensions;

public static class StartupExtension
{
    private static IServiceCollection _services { get; set; }

    public static void RegisterApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        _services = services ?? throw new ArgumentNullException(nameof(services));

        _services.AddScoped<ResellerAppService>();

    }
}
