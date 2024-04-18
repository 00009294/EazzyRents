using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EazzyRents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDateInReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51ef996e-9215-4845-bf25-95b62d51d11e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b40ec1fd-3afd-4714-a871-deebb797d340");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f880d7c8-2cf9-4dfc-97cc-66a611eb5d2b");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "RealEstateRatingAndReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5c485a0a-6c98-47f8-88a7-7b7a6cb9a341", null, "Landlord", "LANDLORD" },
                    { "7a27db8c-1be9-4c27-96ef-bebc292c8db9", null, "Tenant", "TENANT" },
                    { "b87ebcfe-c81a-4f4f-9d97-70bb27ca93e3", null, "Guest", "GUEST" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c485a0a-6c98-47f8-88a7-7b7a6cb9a341");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a27db8c-1be9-4c27-96ef-bebc292c8db9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b87ebcfe-c81a-4f4f-9d97-70bb27ca93e3");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "RealEstateRatingAndReviews");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "51ef996e-9215-4845-bf25-95b62d51d11e", null, "Landlord", "LANDLORD" },
                    { "b40ec1fd-3afd-4714-a871-deebb797d340", null, "Tenant", "TENANT" },
                    { "f880d7c8-2cf9-4dfc-97cc-66a611eb5d2b", null, "Guest", "GUEST" }
                });
        }
    }
}
