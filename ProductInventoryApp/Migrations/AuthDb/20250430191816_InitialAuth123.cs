using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductInventoryApp.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class InitialAuth123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e17b659e-eada-4c9a-8e3a-71551dc7f5a4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3dee988-1138-4d6f-9a13-8348e0a336e5", "AQAAAAIAAYagAAAAELl2kjn7Dx4vmFdA4+bu9BPSlLDuo0iEXKaLQAC4g1mpbrShvoq8UNCveZGNUY/mGQ==", "292ce229-0ae4-4b3e-8f9e-477030715d41" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e17b659e-eada-4c9a-8e3a-71551dc7f5a4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5023acd9-0b38-4dec-9611-72b94680d13b", "AQAAAAIAAYagAAAAENRSuxS3aA+f1XpKu1YBWYcDK+hoaQ9fd/FgUbhP0L7LDd1w0KRbh9KRlNBdu+9hDg==", "d495098c-43ef-4f23-a8d0-148bba240d66" });
        }
    }
}
