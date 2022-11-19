using ApiTechnicalTest.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ApiTechnicalTest.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<OrderDetailEntity>().HasKey(elm => new { elm.ProductId, elm.OrderId });

            const string SUPER_ADMIN_ID = "4e9d145b-ee4d-4a53-a97c-460559f38b90";
            const string ROLE_ID = "a9c5f5f8-213f-423c-b531-8c0dfe23f580";
            const string SUPPLIER_ID = "91a1947f-775a-46b0-80f5-e0ec596f9662";
            const string CATEGORY_ID = "451747c3-e532-4a7c-a7d8-088bb156eb58";
            const string PRODUCT_ID = "0889e287-d770-42dd-9d74-64ad2d43cf9e";

            // seed admin roles
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ROLE_ID,
                    Name = "Super Administrator",
                    NormalizedName = "SUPER_ADMIN",
                    ConcurrencyStamp = ROLE_ID
                }
            );

            // create user
            var user = new IdentityUser
            {
                Id = SUPER_ADMIN_ID,
                UserName = "mcubico",
                Email = "mcubico33@gmail.com",
                EmailConfirmed = true,
                NormalizedUserName = "mcubico33@gmail.com"
            };

            //set user password
            var passwordHasher = new PasswordHasher<IdentityUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "4dm1n***");

            //seed users
            builder.Entity<IdentityUser>().HasData(user);

            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = SUPER_ADMIN_ID
            });

            // seed suppliers
            builder.Entity<SupplierEntity>().HasData(
                new SupplierEntity
                {
                    Id = new Guid(SUPPLIER_ID),
                    SupplierId = "AB-12345",
                    CompanyName = "Supplier name",
                    ContactName = "Contact name",
                    Address = "Address",
                    City = "Cyty",
                    Country = "Country",
                    Phone = "3112222222",
                    HomePage = "https://www.supplier.com",
                }
            );

            // seed categories
            builder.Entity<CategoryEntity>().HasData(
                new CategoryEntity
                {
                    Id = new Guid(CATEGORY_ID),
                    Name= "Pants",
                    Description = "Pants for women and men",
                    Picture = "pants.jpg"
                }
            );

            // seed products
            builder.Entity<ProductEntity>().HasData(
                new ProductEntity
                {
                    Id = new Guid(PRODUCT_ID),
                    Name = "Jean",
                    QuantityPerUnit= 10,
                    UnitPrice = 49900,
                    UnitsInStock= 50,
                    CategoryId= new Guid(CATEGORY_ID),
                    SupplierId= new Guid(SUPPLIER_ID)
                }
            );
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
