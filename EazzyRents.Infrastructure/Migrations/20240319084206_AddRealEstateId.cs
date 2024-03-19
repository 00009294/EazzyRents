using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EazzyRents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRealEstateId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "235e4939-ca1f-4dfe-a9be-24be8e619d60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57487993-2294-4907-80e2-441525388b85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8457c89-4990-42b7-b27a-a87baa177dc9");

            migrationBuilder.AddColumn<int>(
                name: "RealEstateId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2718ef3b-db11-4ace-a87a-76789e12afb7", null, "Tenant", "TENANT" },
                    { "5007067d-7cba-4cf7-8103-3ccd77a95dc8", null, "Landlord", "LANDLORD" },
                    { "fbc04dcf-46a1-4456-b611-9f09a68d84b6", null, "Guest", "GUEST" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_RealEstateId",
                table: "Images",
                column: "RealEstateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_RealEstates_RealEstateId",
                table: "Images",
                column: "RealEstateId",
                principalTable: "RealEstates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_RealEstates_RealEstateId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_RealEstateId",
                table: "Images");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2718ef3b-db11-4ace-a87a-76789e12afb7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5007067d-7cba-4cf7-8103-3ccd77a95dc8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbc04dcf-46a1-4456-b611-9f09a68d84b6");

            migrationBuilder.DropColumn(
                name: "RealEstateId",
                table: "Images");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "235e4939-ca1f-4dfe-a9be-24be8e619d60", null, "Guest", "GUEST" },
                    { "57487993-2294-4907-80e2-441525388b85", null, "Landlord", "LANDLORD" },
                    { "d8457c89-4990-42b7-b27a-a87baa177dc9", null, "Tenant", "TENANT" }
                });
        }
    }
}
