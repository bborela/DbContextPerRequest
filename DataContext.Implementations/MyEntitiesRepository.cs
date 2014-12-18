using DataContext.Interfaces;

namespace DataContext.Implementations
{
    public class MyEntitiesRepository<TEntity> : BaseRepository<MyEntities, TEntity>
        where TEntity : BaseEntity
    {
        public MyEntitiesRepository(IDataContext<MyEntities> dataContext) : base(dataContext)
        {
        }
    }
}
