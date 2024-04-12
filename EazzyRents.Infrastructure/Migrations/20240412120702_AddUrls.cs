using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EazzyRents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUrls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf3072fe-fded-4570-9cac-2fed9bcf386c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6147445-fd29-4cce-a8ce-3dccfe777db8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa6968b4-5749-4296-93ca-208c6b0050dc");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrls",
                table: "RealEstates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f92cab9-9253-466b-8572-9dbe15abb26a", null, "Guest", "GUEST" },
                    { "4fad90a7-cd10-4e9d-bb50-627bfa1ff8da", null, "Landlord", "LANDLORD" },
                    { "58d009b4-6bc7-47c5-be5f-a529d49c1775", null, "Tenant", "TENANT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "ImageUrls",
                table: "RealEstates");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bf3072fe-fded-4570-9cac-2fed9bcf386c", null, "Tenant", "TENANT" },
                    { "f6147445-fd29-4cce-a8ce-3dccfe777db8", null, "Guest", "GUEST" },
                    { "fa6968b4-5749-4296-93ca-208c6b0050dc", null, "Landlord", "LANDLORD" }
                });
        }
    }
}
