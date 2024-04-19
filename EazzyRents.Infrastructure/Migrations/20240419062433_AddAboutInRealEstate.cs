using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EazzyRents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAboutInRealEstate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "RealEstates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3fad32ec-f743-4669-b470-02992c3d2ab4", null, "Landlord", "LANDLORD" },
                    { "47af7ec8-c0d3-4c07-91b4-bf80ea2a843a", null, "Tenant", "TENANT" },
                    { "9d2a430e-4d6b-4a39-a3bd-00bd48eeb48b", null, "Guest", "GUEST" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fad32ec-f743-4669-b470-02992c3d2ab4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47af7ec8-c0d3-4c07-91b4-bf80ea2a843a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d2a430e-4d6b-4a39-a3bd-00bd48eeb48b");

            migrationBuilder.DropColumn(
                name: "About",
                table: "RealEstates");

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
    }
}
