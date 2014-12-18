using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataContext.Interfaces
{
    /// <summary>
    /// Not a proper repository because EF doesn't actually need one. Just an interface
    /// for the most common operations you have to perform on your DbContext. Note: you
    /// shouldn't ever have to call DbContext.SaveChanges inside a repository.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Find(object key);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
