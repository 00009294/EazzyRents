using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EazzyRents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailPropInRealEstate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c5cb195-27d6-4205-83fa-6e141baf73a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63519eaf-2647-41a3-9511-95993c562088");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d968a743-2d2c-4363-961a-2239894da820");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "RealEstates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "295efbd8-de45-4115-9fcb-c19993291065", null, "Landlord", "LANDLORD" },
                    { "ae1449ff-b7a9-418e-8a76-3dd07874b927", null, "Guest", "GUEST" },
                    { "b978b548-8246-4671-88e8-dfaf13456c22", null, "Tenant", "TENANT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "295efbd8-de45-4115-9fcb-c19993291065");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae1449ff-b7a9-418e-8a76-3dd07874b927");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b978b548-8246-4671-88e8-dfaf13456c22");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "RealEstates");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5c5cb195-27d6-4205-83fa-6e141baf73a2", null, "Landlord", "LANDLORD" },
                    { "63519eaf-2647-41a3-9511-95993c562088", null, "Guest", "GUEST" },
                    { "d968a743-2d2c-4363-961a-2239894da820", null, "Tenant", "TENANT" }
                });
        }
    }
}
