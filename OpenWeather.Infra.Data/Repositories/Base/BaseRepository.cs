using Microsoft.EntityFrameworkCore;
using OpenWeather.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather.Infra.Data.Repositories.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        protected BaseRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return (await _context.Set<TEntity>().AddAsync(entity)).Entity;
        }

        public async Task AddAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public TEntity Remove(TEntity entity)
        {
            return _context.Set<TEntity>().Remove(entity).Entity;
        }

        public void Remove(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public TEntity Update(TEntity entity)
        {
            var result = _context.Set<TEntity>().Update(entity).Entity;
            _context.Entry(entity).State = EntityState.Modified;
            return result;
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _context.Set<TEntity>().AnyAsync(where);
        }

        public async Task<TEntity?> GetAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync<TKey>(Expression<Func<TEntity, TKey>> order, bool ascOrder)
        {
            return ascOrder
                ? await _context.Set<TEntity>().OrderBy(order).ToListAsync()
                : await _context.Set<TEntity>().OrderByDescending(order).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where, bool tracking = true)
        {
            return tracking
                ? await _context.Set<TEntity>().Where(where).ToListAsync()
                : await _context.Set<TEntity>().AsNoTracking().Where(where).ToListAsync();
        }

        public async Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>> where, bool tracking = true)
        {
            return tracking
                ? await _context.Set<TEntity>().FirstOrDefaultAsync(where)
                : await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(where);
        }
    }
}
