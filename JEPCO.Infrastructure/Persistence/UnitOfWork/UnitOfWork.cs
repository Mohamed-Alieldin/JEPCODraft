using JEPCO.Application.Interfaces.Repositories;
using JEPCO.Application.Interfaces.UnitOfWork;
using JEPCO.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace JEPCO.Infrastructure.Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext dbContext;
    private IResellerRepo _resellerRepo;
    public UnitOfWork(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IResellerRepo ResellerRepo
    {
        get
        {
            _resellerRepo ??= new ResellerRepo(dbContext);
            return _resellerRepo;
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
