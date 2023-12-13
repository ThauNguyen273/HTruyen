using Core.Entities.Interfaces;

namespace Core.Interfaces.Repositories.Bases;
public interface IRepository<TEntity> where TEntity : IEntity
{
    Task<TEntity?> GetAsync(string id);
    Task<List<TEntity>> GetAllAsync();
    Task CreateAsync(TEntity entity);
    Task ReplaceAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(string id);
}

