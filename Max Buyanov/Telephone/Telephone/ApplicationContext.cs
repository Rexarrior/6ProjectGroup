using System.Data.Entity;

namespace Telephone
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
            Database.SetInitializer<ApplicationContext>(null);
        }
        public DbSet<People> Peoples { get; set; }
    }
}
