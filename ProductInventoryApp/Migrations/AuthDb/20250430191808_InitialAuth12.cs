using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductInventoryApp.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class InitialAuth12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e17b659e-eada-4c9a-8e3a-71551dc7f5a4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5023acd9-0b38-4dec-9611-72b94680d13b", "AQAAAAIAAYagAAAAENRSuxS3aA+f1XpKu1YBWYcDK+hoaQ9fd/FgUbhP0L7LDd1w0KRbh9KRlNBdu+9hDg==", "d495098c-43ef-4f23-a8d0-148bba240d66" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e17b659e-eada-4c9a-8e3a-71551dc7f5a4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "610cc10f-eca7-4e47-8250-8d41b0600148", "AQAAAAIAAYagAAAAEBUBI78i6yAvWil3jTlfa86fNRJ5oWrKv+CwYLdF3ISO3z6rRyvkyE1lBuwdagtbzg==", "59b4b513-ded4-43d5-a45a-8808d82b8461" });
        }
    }
}
