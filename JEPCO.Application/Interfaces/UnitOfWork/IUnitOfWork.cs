using JEPCO.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Storage;


namespace JEPCO.Application.Interfaces.UnitOfWork;

public interface IUnitOfWork
{
    IResellerRepo ResellerRepo { get; }
    int Complete();
    Task<int> CompleteAsync(CancellationToken cancellationToken = new CancellationToken());
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = new CancellationToken());
}
