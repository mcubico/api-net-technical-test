using ApiTechnicalTest.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ApiTechnicalTest.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderDetailEntity>().HasKey(elm => new { elm.ProductId, elm.OrderId });

            base.OnModelCreating(builder);
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<SupplierEntity> Suppliers { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<ShipperEntity> Shippers { get; set; }
        public DbSet<OrderDetailEntity> OrderDetails { get; set; }
    }
}
