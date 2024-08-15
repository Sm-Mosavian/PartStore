namespace PartsStoreAPI.Core.Interfaces;

public interface IGeneralRepository<TEntity> where TEntity : class
{
    
    Task<TEntity> AddAsync(TEntity entity);



}