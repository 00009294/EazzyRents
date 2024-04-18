using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EazzyRents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditIntToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "RealEstateRatingAndReviews",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "SenderId",
                table: "RealEstateRatingAndReviews",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
