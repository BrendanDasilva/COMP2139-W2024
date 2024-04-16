using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1.Migrations
{
    /// <inheritdoc />
    public partial class mssql_migration_712 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7c3051b8-be20-4882-a64c-98fdf128f7bc", "AQAAAAIAAYagAAAAECCS66GEcxduTI1NW5hNLecJG8SYGoKn0D/fU7hiQZEutTqILYRWA8w5hwWh4+rnKg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aafed164-739b-405a-b046-5c5e3efb269d", "AQAAAAIAAYagAAAAEElDqLFC13VdHy9riqHEu3S4ZR+ujKS0h8SULlK2+obnSc2upiBblgPfclvuuipong==" });
        }
    }
}
