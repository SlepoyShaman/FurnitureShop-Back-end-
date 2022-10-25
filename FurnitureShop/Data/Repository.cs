using FurnitureShop.Models;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using System.Data;

namespace FurnitureShop.Data
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
            => _context.Set<TEntity>().Select(p => p);
        public async Task<TEntity> GetByIdAsync<TEntity>(int Id) where TEntity : class, IWithId
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(p => p.Id == Id);
            if (result != null) return result;
            else throw new NullReferenceException();

        }
        public async Task AddNewItemAsync<TEntity>(TEntity item) where TEntity : class
        {
            await _context.Set<TEntity>().AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveByIdAsync<TEntity>(int Id) where TEntity : class, IWithId
        {
            TEntity item = _context.Set<TEntity>().FirstOrDefault(p => p.Id == Id);
            if(item != null)
            {
                _context.Set<TEntity>().Remove(item);
                await _context.SaveChangesAsync();
            }
            else throw new NullReferenceException();

        }
    }
}
