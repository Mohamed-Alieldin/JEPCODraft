using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JEPCO.Application.Extensions;

public static class StartupExtension
{
    private static IServiceCollection _services { get; set; }

    public static void RegisterApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        _services = services;

        // _services.AddScoped<SomeRequestService>();

    }
}
