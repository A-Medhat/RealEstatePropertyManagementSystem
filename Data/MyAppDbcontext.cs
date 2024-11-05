using Microsoft.EntityFrameworkCore;
using realEstate1.Models;

namespace realEstate1.Data
{
    public class MyAppDbcontext : DbContext
    {
        public MyAppDbcontext()
        {
        }

        public MyAppDbcontext(DbContextOptions<MyAppDbcontext>options):base(options) 
        {
            
        }
        public DbSet<Property> properties { get; set; }
        public DbSet<Tenant> tenants { get; set; }
        public DbSet<Lease> leases { get; set; }
        public DbSet<IssueReport> issues { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<PropertyImage> PropertiesImages { get;  set; }
    }
}
