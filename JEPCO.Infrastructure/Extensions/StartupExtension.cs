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
        _services = services ?? throw new ArgumentNullException(nameof(services));
        string connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
            throw new NotImplementedException("Database default connection string is not recognized");

        AddDatabaseContext(connectionString);
        _services.AddScoped<IUnitOfWork, UnitOfWork>();
        _services.AddScoped<ICacheManagement, RedisCacheManagement>();

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


    public static void MigrateDatabaseToLatestVersion(IServiceProvider services)
    {
        using (var scope = services.CreateScope())
        {
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();
        }
    }
}
