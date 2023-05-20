using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Users.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedAllScope : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "scopes",
                columns: new[] { "id", "name" },
                values: new object[] { 5, "All" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "scopes",
                keyColumn: "id",
                keyValue: 5);
        }
    }
}
