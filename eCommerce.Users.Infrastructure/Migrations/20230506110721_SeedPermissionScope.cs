using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eCommerce.Users.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedPermissionScope : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "permission_scope",
                columns: new[] { "permission_id", "scope_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "permission_scope",
                keyColumns: new[] { "permission_id", "scope_id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "permission_scope",
                keyColumns: new[] { "permission_id", "scope_id" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "permission_scope",
                keyColumns: new[] { "permission_id", "scope_id" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "permission_scope",
                keyColumns: new[] { "permission_id", "scope_id" },
                keyValues: new object[] { 1, 4 });
        }
    }
}
