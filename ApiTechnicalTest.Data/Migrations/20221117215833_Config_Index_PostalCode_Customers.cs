using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTechnicalTest.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigIndexPostalCodeCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customers_PostalCode",
                table: "Customers",
                column: "PostalCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_PostalCode",
                table: "Customers");
        }
    }
}
