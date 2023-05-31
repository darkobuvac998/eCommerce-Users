using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Users.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewRoleSuperAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "name" },
                values: new object[] { 6, "SuperAdmin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 6);
        }
    }
}
