using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    //DbContext veritabanını yönetir ve db ile uygulama arasında köprü işlevi görür.
    //veritabanı modelini nesne tabanlı şekilde temsil eder.
    public class ProductTrackingDbContext:DbContext
       
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-9MFQJV2;Initial Catalog=ProductTrackingDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
