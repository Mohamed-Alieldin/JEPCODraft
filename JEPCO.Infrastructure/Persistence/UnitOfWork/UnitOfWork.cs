using JEPCO.Application.Interfaces.Repositories;
using JEPCO.Application.Interfaces.UnitOfWork;
using JEPCO.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEPCO.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;
        private IWeatherForecastRepo _weatherForecastRepo;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IWeatherForecastRepo WeatherForecastRepo
        {
            get
            {
                _weatherForecastRepo ??= new WeatherForecastRepo(dbContext);
                return _weatherForecastRepo;
            }
        }
        public int Complete()
        {
            return dbContext.SaveChanges();
        }
        public Task<int> CompleteAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return dbContext.Database.BeginTransactionAsync(cancellationToken);
        }
    }
}
