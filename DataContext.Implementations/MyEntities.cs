using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;

namespace DataContext.Implementations
{
    public class MyEntities : DbContext
    {
        public MyEntities() : base("")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
