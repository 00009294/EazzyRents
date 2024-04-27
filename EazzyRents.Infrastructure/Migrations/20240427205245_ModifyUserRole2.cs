using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EazzyRents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyUserRole2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e071bf9-e496-44a9-80a3-7e011457d560");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34d3dad7-c6ce-43cf-bfa8-5121ea13adf4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b54b46e2-aab8-4ca2-97e6-995cd1537dec");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9e9e05ff-1f41-4994-8aa1-28ae0f770c79", null, "Tenant", "TENANT" },
                    { "b64ddc5a-64bd-4e84-8053-10a3bdfb9f42", null, "Landlord", "LANDLORD" },
                    { "d901ead4-3382-4280-a808-e0273ce96324", null, "Guest", "GUEST" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e9e05ff-1f41-4994-8aa1-28ae0f770c79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b64ddc5a-64bd-4e84-8053-10a3bdfb9f42");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d901ead4-3382-4280-a808-e0273ce96324");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e071bf9-e496-44a9-80a3-7e011457d560", null, "Landlord", "LANDLORD" },
                    { "34d3dad7-c6ce-43cf-bfa8-5121ea13adf4", null, "Tenant", "TENANT" },
                    { "b54b46e2-aab8-4ca2-97e6-995cd1537dec", null, "Guest", "GUEST" }
                });
        }
    }
}
