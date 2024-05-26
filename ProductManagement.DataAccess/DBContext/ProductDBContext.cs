using ProductManagement.DataAccess.Objects;
using Microsoft.EntityFrameworkCore;

namespace ProductManagement.DataAccess.DBContext
{
    public class ProductDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-DBAC4GV\\SQLEXPRESS;Initial Catalog=ProductDB;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;TrustServerCertificate=True");
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryDetail> CategoryDetails { get; set; }
        public virtual DbSet<ProductVariant> ProductVariants { get; set; }

    }
}
