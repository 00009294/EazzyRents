using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EazzyRents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: "2f92cab9-9253-466b-8572-9dbe15abb26a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fad90a7-cd10-4e9d-bb50-627bfa1ff8da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58d009b4-6bc7-47c5-be5f-a529d49c1775");


            migrationBuilder.DropColumn(
                name: "RealEstateId",
                table: "Images");

            migrationBuilder.AlterColumn<int>(
                name: "Address",
                table: "RealEstates",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "RealEstates",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");



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
                    { "2f92cab9-9253-466b-8572-9dbe15abb26a", null, "Guest", "GUEST" },
                    { "4fad90a7-cd10-4e9d-bb50-627bfa1ff8da", null, "Landlord", "LANDLORD" },
                    { "58d009b4-6bc7-47c5-be5f-a529d49c1775", null, "Tenant", "TENANT" }
                });


            migrationBuilder.AddForeignKey(
                name: "FK_Images_RealEstates_RealEstateId",
                table: "Images",
                column: "RealEstateId",
                principalTable: "RealEstates",
                principalColumn: "Id");

        }
    }
}
