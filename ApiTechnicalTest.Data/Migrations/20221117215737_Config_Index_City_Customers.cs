using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTechnicalTest.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigIndexCityCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customers_City",
                table: "Customers",
                column: "City");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_City",
                table: "Customers");
        }
    }
}
