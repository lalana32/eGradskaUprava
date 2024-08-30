using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d57f95f-9a41-4e5f-bd36-d15ec9d68643");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35a59904-bd30-45bd-b24e-e7c6badbc073");

            migrationBuilder.AddColumn<string>(
                name: "AdresaPrebivalista",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DatumRodjenja",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "OpstinaPrebivalista",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pol",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f0d30ec-8b83-4249-a8ca-a242a55b3e98", null, "Member", "MEMBER" },
                    { "fe31bac2-ffa0-4cfe-b926-8ea3d337db3b", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f0d30ec-8b83-4249-a8ca-a242a55b3e98");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe31bac2-ffa0-4cfe-b926-8ea3d337db3b");

            migrationBuilder.DropColumn(
                name: "AdresaPrebivalista",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DatumRodjenja",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OpstinaPrebivalista",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Pol",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d57f95f-9a41-4e5f-bd36-d15ec9d68643", null, "Member", "MEMBER" },
                    { "35a59904-bd30-45bd-b24e-e7c6badbc073", null, "Admin", "ADMIN" }
                });
        }
    }
}
