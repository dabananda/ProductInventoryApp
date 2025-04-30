using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductInventoryApp.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class InitialAuth1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e17b659e-eada-4c9a-8e3a-71551dc7f5a4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "610cc10f-eca7-4e47-8250-8d41b0600148", "AQAAAAIAAYagAAAAEBUBI78i6yAvWil3jTlfa86fNRJ5oWrKv+CwYLdF3ISO3z6rRyvkyE1lBuwdagtbzg==", "59b4b513-ded4-43d5-a45a-8808d82b8461" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e17b659e-eada-4c9a-8e3a-71551dc7f5a4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fa436a2-c2f6-4a82-bfcd-73f4e39be3e9", "AQAAAAIAAYagAAAAEInAvFqyS7JWVbYFCd/SmSjc5Srx+xqbTw8a7h+iit7uoxfqwHS8Uqrw83fI9yp1qg==", "d2992b85-030e-4e14-a565-a3a29dceb1e3" });
        }
    }
}
