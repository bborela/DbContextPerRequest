using DataContext.Interfaces;

namespace DataContext.Implementations
{
    /// <summary>
    /// This interface is used merely so we can easily bind it to the implementation using Unity
    /// </summary>
    public interface IMyEntitiesDataContext : IDataContext<MyEntities>
    {
         
    }
}