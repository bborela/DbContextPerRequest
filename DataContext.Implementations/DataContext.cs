using System;
using System.Data.Entity;
using DataContext.Interfaces;

namespace DataContext.Implementations
{
    public abstract class DataContext<TDbContext>
        : IDataContext<TDbContext> where TDbContext : DbContext
    {
        public abstract TDbContext Context { get; }

        public int Save()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public abstract void Dispose(bool disposing);
    }
}
