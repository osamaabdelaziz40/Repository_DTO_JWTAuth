using Microsoft.EntityFrameworkCore;
using PRJ.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PRJ.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MainContext _context;
        private DbSet<T> _dbSet;
        public Repository(MainContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            if (entity is null) throw new ArgumentNullException("entity");

            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void AddRangeEntity(List<T> entity)
        {
            if (entity is null) throw new ArgumentNullException("entity");

            _dbSet.AddRange(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<long> Count(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).LongCountAsync();
        }

        public async Task<T> Get(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public T GetSync(long id)
        {
            return _dbSet.Find(id);
        }

        public T GetSync(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public List<T> GetAllSync(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public void Remove(T entity)
        {
            if (entity is null) throw new ArgumentNullException("entity");

            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public void Remove(List<T> entities)
        {
            if (entities.Any())
            {
                _dbSet.RemoveRange(entities);
                _context.SaveChanges();
            }
            else
                throw new ArgumentNullException("entities");
        }

        public void Update(T entity)
        {
            if (entity is null) throw new ArgumentNullException("entity");

            _context.SaveChanges();
        }
    }
}
