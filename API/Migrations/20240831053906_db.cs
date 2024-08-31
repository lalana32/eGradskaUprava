using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94e20b8a-1997-4d50-b1f8-e7a47ef454c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd9da859-dbda-4586-9e59-12c75656f8aa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "98ca9eb9-8043-40cd-a55d-bdfae6357284", null, "Admin", "ADMIN" },
                    { "d809d96e-c23c-465b-8f5d-b3fdc1f8a4dd", null, "Member", "MEMBER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98ca9eb9-8043-40cd-a55d-bdfae6357284");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d809d96e-c23c-465b-8f5d-b3fdc1f8a4dd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "94e20b8a-1997-4d50-b1f8-e7a47ef454c9", null, "Member", "MEMBER" },
                    { "fd9da859-dbda-4586-9e59-12c75656f8aa", null, "Admin", "ADMIN" }
                });
        }
    }
}
