using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PRJ.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        T GetSync(Expression<Func<T, bool>> predicate);
        T GetSync(long id);
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate);
        List<T> GetAllSync(Expression<Func<T, bool>> predicate);
        Task<T> Get(long id);
        Task<T> Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> AsQueryable();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Remove(List<T> entities);
        Task<long> Count(Expression<Func<T, bool>> predicate);
        void AddRangeEntity(List<T> entity);
    }
}
