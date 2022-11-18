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
                table: "Suppliers",
                columns: new[] { "Id", "Active", "Address", "City", "CompanyName", "ContactName", "ContactTitle", "Country", "Fax", "HomePage", "Phone", "PostalCode", "Region", "SupplierId" },
                values: new object[] { new Guid("4e9d145b-ee4d-4a53-a97c-460559f38b90"), true, "Address", "Cyty", "Supplier name", "Contact name", null, "Country", null, "https://www.supplier.com", "3112222222", null, null, "AB-12345" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("4e9d145b-ee4d-4a53-a97c-460559f38b90"));
        }
    }
}
