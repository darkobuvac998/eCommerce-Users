using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eCommerce.Users.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedScopesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "scopes",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Edit" },
                    { 2, "Add" },
                    { 3, "View" },
                    { 4, "Delete" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "scopes",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "scopes",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "scopes",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "scopes",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
