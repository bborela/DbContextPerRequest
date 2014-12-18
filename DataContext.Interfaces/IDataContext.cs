using System;
using System.Data.Entity;

namespace DataContext.Interfaces
{
    public interface IDataContext<out TDbContext> : IDisposable
        where TDbContext : DbContext
    {
        TDbContext Context { get; }
        int Save();
    }
}