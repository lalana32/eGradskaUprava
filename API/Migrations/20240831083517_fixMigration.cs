using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class fixMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98ca9eb9-8043-40cd-a55d-bdfae6357284");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d809d96e-c23c-465b-8f5d-b3fdc1f8a4dd");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentTypeID",
                table: "AppointmentTypes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            /*migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3084a596-5fdf-4192-84ba-a285ebcef535", null, "Admin", "ADMIN" },
                    { "a58e2868-1d3a-410b-9d1c-b4cfa33fffee", null, "Member", "MEMBER" }
                });*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3084a596-5fdf-4192-84ba-a285ebcef535");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a58e2868-1d3a-410b-9d1c-b4cfa33fffee");

            migrationBuilder.AlterColumn<string>(
                name: "AppointmentTypeID",
                table: "AppointmentTypes",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            /*migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "98ca9eb9-8043-40cd-a55d-bdfae6357284", null, "Admin", "ADMIN" },
                    { "d809d96e-c23c-465b-8f5d-b3fdc1f8a4dd", null, "Member", "MEMBER" }
                });*/
        }
    }
}
