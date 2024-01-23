using Core.Entities.Interfaces;
using System.Linq.Expressions;

namespace Core.Interfaces.Repositories.Bases;
public interface IRepository<TEntity> where TEntity : IEntity
{
    Task<TEntity?> GetAsync(string id);
    Task<TEntity> GetByEmailAsync(string email);
    Task<IEnumerable<TEntity>> GetByFieldAsync(Expression<Func<TEntity, bool>> filter);
    Task<List<TEntity>> GetAllAsync();
    Task CreateAsync(TEntity entity);
    Task ReplaceAsync(TEntity entity);
    Task ReplaceAsync(string id, TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(string id);
    Task DeleteByFieldAsync(Expression<Func<TEntity, bool>> filter);
}

