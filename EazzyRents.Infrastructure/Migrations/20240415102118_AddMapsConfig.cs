using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EazzyRents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMapsConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3337eafc-3b57-44d8-bc09-9e80399fadfa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7801f0b-f89d-466d-abad-2ab50a7573b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8dfb775-00b8-4445-96f0-5312b2c1d99f");

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "RealEstates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "RealEstates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "36149f43-3dd1-424e-b684-27605cbdc650", null, "Guest", "GUEST" },
                    { "61032db0-a9c7-48c6-bb05-ad7466fba42b", null, "Landlord", "LANDLORD" },
                    { "cac19130-9013-4288-bd9d-94edccb38540", null, "Tenant", "TENANT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36149f43-3dd1-424e-b684-27605cbdc650");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61032db0-a9c7-48c6-bb05-ad7466fba42b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac19130-9013-4288-bd9d-94edccb38540");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "RealEstates");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "RealEstates");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3337eafc-3b57-44d8-bc09-9e80399fadfa", null, "Guest", "GUEST" },
                    { "a7801f0b-f89d-466d-abad-2ab50a7573b1", null, "Landlord", "LANDLORD" },
                    { "e8dfb775-00b8-4445-96f0-5312b2c1d99f", null, "Tenant", "TENANT" }
                });
        }
    }
}
