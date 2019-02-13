using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FunBooksAndVideos.DataLayer.Abstracts;

namespace FunBooksAndVideos.DataLayer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _dataContext;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        private DbSet<T> DbSet()
        {
            return _dataContext.Set<T>();
        }

        public IQueryable<T> Entity()
        {
            return DbSet();
        }

        public IQueryable<T> Filter(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            var dbSet = DbSet().Where(predicate).AsQueryable();

            if (includes == null || !includes.Any()) return dbSet;

            return includes.Aggregate(dbSet, (current, include) => current.Include(include));
        }

        public T Find(params object[] keys)
        {
            return DbSet().Find(keys);
        }

        public async Task<T> FindAsync(params object[] keys)
        {
            return await DbSet().FindAsync(keys);
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet().FirstOrDefault(predicate);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet().FirstOrDefaultAsync(predicate);
        }

        public T Insert(T entity)
        {
            DbSet().Add(entity);

            return entity;
        }

        public async Task<T> InsertAsync(T entity)
        {
            await DbSet().AddAsync(entity);

            return entity;
        }

        public void Update(T entity)
        {
            DbSet().Attach(entity);

            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            DbSet().Remove(entity);
        }

        public void Commit()
        {
            _dataContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
