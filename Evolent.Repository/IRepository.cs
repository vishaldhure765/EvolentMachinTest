using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> FindAllAsync();

        Task<List<T>> FindAllAsync(Expression<Func<T, bool>> predicate);

        Task<T> FindAsync();

        Task<T> FindAsync(Expression<Func<T, bool>> predicate);

        Task<T> InsertAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T> DeleteAsync(T entity);

        Task<T> InsertOrUpdateAsync(T entity, object id);

    }
}
