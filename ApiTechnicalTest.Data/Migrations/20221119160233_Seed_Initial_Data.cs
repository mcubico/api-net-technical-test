using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTechnicalTest.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a9c5f5f8-213f-423c-b531-8c0dfe23f580", "a9c5f5f8-213f-423c-b531-8c0dfe23f580", "Super Administrator", "SUPER_ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4e9d145b-ee4d-4a53-a97c-460559f38b90", 0, "d52c6b51-ec55-497e-8ee8-25e9dc3902ca", "mcubico33@gmail.com", true, false, null, null, "mcubico33@gmail.com", "AQAAAAIAAYagAAAAEC0qD6oGDQEOJ0U81rsWUt90IOa1pvWNn07M7J4bwZvHdHo6Rt8iRMkajEwYMhQskQ==", null, false, "fee718a8-a9f6-4a0b-ad42-3f8cd42ec0c5", false, "mcubico" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Active", "Description", "Name", "Picture" },
                values: new object[] { new Guid("451747c3-e532-4a7c-a7d8-088bb156eb58"), true, "Pants for women and men", "Pants", "pants.jpg" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Active", "Address", "City", "CompanyName", "ContactName", "ContactTitle", "Country", "Fax", "HomePage", "Phone", "PostalCode", "Region", "SupplierId" },
                values: new object[] { new Guid("91a1947f-775a-46b0-80f5-e0ec596f9662"), true, "Address", "Cyty", "Supplier name", "Contact name", null, "Country", null, "https://www.supplier.com", "3112222222", null, null, "AB-12345" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a9c5f5f8-213f-423c-b531-8c0dfe23f580", "4e9d145b-ee4d-4a53-a97c-460559f38b90" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "CategoryId", "Discontinuated", "Name", "QuantityPerUnit", "RecorderLevel", "SupplierId", "UnitPrice", "UnitsInStock", "UnitsOnOrder" },
                values: new object[] { new Guid("0889e287-d770-42dd-9d74-64ad2d43cf9e"), true, new Guid("451747c3-e532-4a7c-a7d8-088bb156eb58"), false, "Jean", 10, null, new Guid("91a1947f-775a-46b0-80f5-e0ec596f9662"), 49900m, 50, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a9c5f5f8-213f-423c-b531-8c0dfe23f580", "4e9d145b-ee4d-4a53-a97c-460559f38b90" });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0889e287-d770-42dd-9d74-64ad2d43cf9e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9c5f5f8-213f-423c-b531-8c0dfe23f580");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4e9d145b-ee4d-4a53-a97c-460559f38b90");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("451747c3-e532-4a7c-a7d8-088bb156eb58"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("91a1947f-775a-46b0-80f5-e0ec596f9662"));
        }
    }
}
