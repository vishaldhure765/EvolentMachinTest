using Evolent.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;

        private DbSet<T> entities;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public async Task<List<T>> FindAllAsync()
        {
            return await entities.ToListAsync();
        }

        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await entities.Where(predicate).ToListAsync();
        }

        public Task<T> FindAsync()
        {
            return entities.FirstOrDefaultAsync();
        }
        public Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return entities.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await entities.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> InsertOrUpdateAsync(T entity, object id)
        {
            var record = entities.Find(id);
            if (record != null)
                await UpdateAsync(entity);
            else
            {
                await InsertAsync(entity);
            }
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        //public void SaveChanges()
        //{
        //    context.SaveChanges();
        //}

        //public void Dispose()
        //{
        //    context.Dispose();
        //}

    }
}
