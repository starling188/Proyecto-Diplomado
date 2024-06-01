using Domain.Interface.Repository;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Core
{
    public abstract class GenericRepositories<T> : IGenericRepository<T> where T : class
    {
        protected readonly RestaurantContext _context;
        protected readonly DbSet<T> _dbSet;

        protected GenericRepositories(RestaurantContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);

        }

        public async Task AddList(List<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);

        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);

            }
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {

            _context.Entry(entity).State = EntityState.Modified;

        }
    }
}
