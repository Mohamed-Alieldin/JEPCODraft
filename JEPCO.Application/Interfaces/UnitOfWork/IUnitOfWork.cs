using JEPCO.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEPCO.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IWeatherForecastRepo WeatherForecastRepo { get; }
        int Complete();
        Task<int> CompleteAsync(CancellationToken cancellationToken = new CancellationToken());
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
