using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DataContext.Interfaces;

namespace DataContext.Implementations
{
    public abstract class BaseRepository<TDbContext, TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
        where TDbContext : DbContext
    {
        protected TDbContext Context;

        protected BaseRepository(IDataContext<TDbContext> dataContext)
        {
            Context = dataContext.Context;
        }

        public TEntity Find(object key)
        {
            return Context.Set<TEntity>().Find(key);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity Add(TEntity entity)
        {
            return Context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            if (Context.Entry(entity).State != EntityState.Deleted)
                Context.Set<TEntity>().Remove(entity);
        }

    }
}
