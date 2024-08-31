using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class RegisterDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3084a596-5fdf-4192-84ba-a285ebcef535");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a58e2868-1d3a-410b-9d1c-b4cfa33fffee");

            /*migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39695e32-1bbe-497e-b5c1-75cd0c7205ad", null, "Admin", "ADMIN" },
                    { "c7b7b90d-88c8-4934-a09c-d200f8958ff8", null, "Member", "MEMBER" }
                });*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39695e32-1bbe-497e-b5c1-75cd0c7205ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7b7b90d-88c8-4934-a09c-d200f8958ff8");

            /*migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3084a596-5fdf-4192-84ba-a285ebcef535", null, "Admin", "ADMIN" },
                    { "a58e2868-1d3a-410b-9d1c-b4cfa33fffee", null, "Member", "MEMBER" }
                });*/
        }
    }
}
