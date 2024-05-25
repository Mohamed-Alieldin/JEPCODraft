using JEPCO.Application.Interfaces.CacheManagement;
using JEPCO.Application.Interfaces.UnitOfWork;
using JEPCO.Infrastructure.CacheManagement;
using JEPCO.Infrastructure.Persistence;
using JEPCO.Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JEPCO.Infrastructure.Extensions;

public static class StartupExtension
{
    private static IServiceCollection _services { get; set; }

    public static void RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        _services = services;
        string connectionString = configuration.GetConnectionString("DefaultConnection");
        AddDatabaseContext(connectionString);
        _services.AddScoped<IUnitOfWork, UnitOfWork>();
        _services.AddScoped<ICacheManagement, RedisCacheManagement>();

        // _services.AddScoped<SomeRequestService>();

    }
    private static void AddDatabaseContext(string connectionString)
    {
        _services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString, builder =>
            {
                builder.MigrationsHistoryTable("Migrations");
            });
        });
    }
}
