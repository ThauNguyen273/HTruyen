using Core.Entities.Interfaces;
using Core.Interfaces.Repositories.Bases;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Core.Repositories.Bases;
public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : IEntity
{
    protected readonly Database Database;

    public Repository(Database database)
    {
        Database = database;
    }

    public virtual async Task<TEntity?> GetAsync(string id)
    {
        var entity = await Database.Collection<TEntity>()
            .Find(x => x.Id == id)
            .FirstOrDefaultAsync();

        return entity;
    }
    public virtual async Task<TEntity> GetByEmailAsync(string email)
    {
        var entity = await Database.Collection<TEntity>()
            .Find(e => (e as IEntityWithEmail).Email == email)
            .FirstOrDefaultAsync();

        return entity;
    }
    public virtual async Task<IEnumerable<TEntity>> GetByFieldAsync(Expression<Func<TEntity, bool>> filter)
    {
        var entities = await Database.Collection<TEntity>()
            .Find(filter)
            .ToListAsync();

        return entities;
    }
    public virtual async Task<List<TEntity>> GetAllAsync()
    {
        var entities = await Database.Collection<TEntity>()
        .Find(_ => true)
        .ToListAsync();

        return entities;
    }
    public virtual async Task CreateAsync(TEntity entity)
    {
        await Database.Collection<TEntity>()
            .InsertOneAsync(entity);
    }
    public virtual async Task ReplaceAsync(TEntity entity)
    {
        var result = await Database.Collection<TEntity>()
            .ReplaceOneAsync(x => x.Id == entity.Id, entity);

        if (result.ModifiedCount == 0)
        {
            throw new Exception("ReplaceOne.ModifiedCount is 0.");
        }
    }
    public virtual async Task ReplaceAsync(string id, TEntity entity)
    {
        var filter = Builders<TEntity>.Filter.Eq("_id", id);
        await Database.Collection<TEntity>().ReplaceOneAsync(filter, entity);
    }
    public virtual async Task UpdateAsync(TEntity entity)
    {
        var filter = Builders<TEntity>.Filter.Eq(u => u.Id, entity.Id);
        await Database.Collection<TEntity>().ReplaceOneAsync(filter, entity);
    }
    public virtual async Task DeleteAsync(string id)
    {
        var result = await Database.Collection<TEntity>()
            .DeleteOneAsync(x => x.Id == id);

        if(result.DeletedCount ==  0)
        {
            throw new KeyNotFoundException();
        }
    }
    public virtual async Task DeleteByFieldAsync(Expression<Func<TEntity, bool>> filter)
    {
        await Database.Collection<TEntity>().DeleteManyAsync(filter);
    }
}