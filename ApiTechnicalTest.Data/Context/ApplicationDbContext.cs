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
            builder.Entity<SupplierEntity>().HasData(new SupplierEntity
            {
                Id = Guid.NewGuid(),
                SupplierId = "AB-12345",
                CompanyName = "Supplier name",
                ContactName = "Contact name",
                Address = "Address",
                City = "Cyty",
                Country = "Country",
                Phone = "3112222222",
                HomePage = "https://www.supplier.com",
            });

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
