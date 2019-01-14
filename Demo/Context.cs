using System.Data.Entity;

namespace Demo
{
    public class Context : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public Context() : base(@"Server=localhost\SQL2017;Database=Demo;Trusted_Connection=True;")
        {
            
        }
    }
}
