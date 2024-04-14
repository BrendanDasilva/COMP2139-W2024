using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                schema: "Identity",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                column: "Location",
                value: "Los Angeles");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                column: "Location",
                value: "San Francisco");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3,
                column: "Location",
                value: "New York");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 4,
                column: "Location",
                value: "Las Vegas");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 5,
                column: "Location",
                value: "Miami");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 6,
                column: "Location",
                value: "Seattle");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 7,
                column: "Location",
                value: "Chicago");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 8,
                column: "Location",
                value: "Boston");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 9,
                column: "Location",
                value: "San Diego");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 10,
                column: "Location",
                value: "Houston");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aafed164-739b-405a-b046-5c5e3efb269d", "AQAAAAIAAYagAAAAEElDqLFC13VdHy9riqHEu3S4ZR+ujKS0h8SULlK2+obnSc2upiBblgPfclvuuipong==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                schema: "Identity",
                table: "Cars");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bfb0b937-d9ff-457e-82fc-1dd640ff860e", "AQAAAAIAAYagAAAAEMIFxOXKnF7n4sldhEtwWWWjp2B4Ca6OXiPTsB2IboxI7vXibxzCKg2/WBJ6qBEuMw==" });
        }
    }
}
