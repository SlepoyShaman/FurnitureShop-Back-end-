using FurnitureShop.Models;

namespace FurnitureShop.Data
{
    public interface IRepository
    {
        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;
        public Task<TEntity> GetByIdAsync<TEntity>(int Id) where TEntity : class, IWithId;
        public Task AddNewItemAsync<TEntity>(TEntity item) where TEntity : class;
        public Task RemoveByIdAsync<TEntity>(int Id) where TEntity : class, IWithId;
    }
}
