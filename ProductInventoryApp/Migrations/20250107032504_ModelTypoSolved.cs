using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductInventoryApp.Migrations
{
    /// <inheritdoc />
    public partial class ModelTypoSolved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MenufactureDate",
                table: "Products",
                newName: "ManufacturerDate");

            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Products",
                newName: "Manufacturer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ManufacturerDate",
                table: "Products",
                newName: "MenufactureDate");

            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "Products",
                newName: "Brand");
        }
    }
}
