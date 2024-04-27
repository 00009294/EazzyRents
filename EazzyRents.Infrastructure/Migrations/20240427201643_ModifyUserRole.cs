using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EazzyRents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e58429a-2760-4244-b83e-53310f2d6f7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34700682-577a-49a4-88d1-08776905c73d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebfdc3be-1a18-4eca-b73e-ce77e4aa94ef");

            migrationBuilder.DropColumn(
                name: "IsLandlord",
                table: "ChatMessages");

            migrationBuilder.AddColumn<int>(
                name: "UserRole",
                table: "ChatMessages",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "ChatMessages");

            migrationBuilder.AddColumn<bool>(
                name: "IsLandlord",
                table: "ChatMessages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e58429a-2760-4244-b83e-53310f2d6f7d", null, "Landlord", "LANDLORD" },
                    { "34700682-577a-49a4-88d1-08776905c73d", null, "Tenant", "TENANT" },
                    { "ebfdc3be-1a18-4eca-b73e-ce77e4aa94ef", null, "Guest", "GUEST" }
                });
        }
    }
}
