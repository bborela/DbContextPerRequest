using DataContext.Interfaces;
using MyDomain;

namespace DbContextPerRequest.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
