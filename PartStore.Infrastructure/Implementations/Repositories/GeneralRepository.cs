
using PartsStoreAPI.Core.Interfaces;


namespace PartStore.Infrastructure.Implementations.Repositories
{
    public class GeneralRepository<TEntity> : IGeneralRepository<TEntity> where TEntity : class
    {
        protected readonly List<TEntity> _entities;
        public GeneralRepository()
        {
            _entities = new List<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            _entities.Add(entity);
            return await Task.FromResult(entity);
        }
    }
}
