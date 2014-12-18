using DataContext.Implementations;
using DataContext.Interfaces;
using DbContextPerRequest.Repositories.Interfaces;
using MyDomain;

namespace DbContextPerRequest.Repositories
{
    public class UserRepository : MyEntitiesRepository<User>, IUserRepository
    {
        public UserRepository(IDataContext<MyEntities> dataContext) : base(dataContext)
        {
        }
    }
}