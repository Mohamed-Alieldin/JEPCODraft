using JEPCO.Application.Interfaces.UnitOfWork;
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
