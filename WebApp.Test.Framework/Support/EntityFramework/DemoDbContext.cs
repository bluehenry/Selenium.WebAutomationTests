using System.Data.Entity;
using WebApp.Test.Framework.Support.EntityFramework.DomainClasses;

namespace WebApp.Test.Framework.Support.EntityFramework
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(string connectionString) : base(connectionString)
        {
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("vdt");
        }
    }
}
