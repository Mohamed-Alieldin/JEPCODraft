using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace JEPCO.Application.Interfaces.Repositories.Base;

/// <summary>
/// Represents a generic repository interface for CRUD operations on entities.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public interface IRepository<TEntity> where TEntity : class
{
    TEntity GetById(int id);

    TEntity GetById(Guid id);

    TEntity GetById(string id);

    IEnumerable<TEntity> GetAll();

    IQueryable<TEntity> GetAllQuerable(Expression<Func<TEntity, bool>> predicate = null);

    void Add(TEntity entity);

    void AddRange(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);

    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
    Task<IEnumerable<TEntity>> GetAllByOrderAsync(Func<TEntity, object> predicate, string sort = "Ascending");

    ValueTask<TEntity> GetByIdAsync(int id);

    ValueTask<TEntity> GetByIdAsync(Guid id);
    ValueTask<TEntity> GetByIdAsync(string id);
    Task<TEntity> GetByIdNoTrackingAsync(Expression<Func<TEntity, bool>> predicate);
    ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    Task<List<TEntity>> GetAllAsync();
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
}
