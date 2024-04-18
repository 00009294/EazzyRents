using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EazzyRents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedOwnerIdInRatings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "ReceiverId",
                table: "RealEstateRatingAndReviews");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "250b0f82-7ac7-4467-8e0d-77883bb04790", null, "Tenant", "TENANT" },
                    { "8c687c32-2046-485c-a4f8-839a6ad76f6b", null, "Guest", "GUEST" },
                    { "fab2f71f-ed26-40b0-8a10-b6457008126e", null, "Landlord", "LANDLORD" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "250b0f82-7ac7-4467-8e0d-77883bb04790");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c687c32-2046-485c-a4f8-839a6ad76f6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab2f71f-ed26-40b0-8a10-b6457008126e");

            migrationBuilder.AddColumn<int>(
                name: "ReceiverId",
                table: "RealEstateRatingAndReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
