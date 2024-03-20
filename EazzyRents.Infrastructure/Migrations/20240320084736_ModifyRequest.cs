using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EazzyRents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2007a5fe-1056-40ee-b814-d1fd5f603703");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d368a31-d91f-444f-a7a8-bde2bd77636d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "827a82d0-ce6a-4415-81e0-5bb1cf3d52d0");

            migrationBuilder.AddColumn<int>(
                name: "RealEstateId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a42387ec-4046-4438-9b45-e5811836fe33", null, "Guest", "GUEST" },
                    { "af665deb-56f7-402d-960e-99780731bfe8", null, "Tenant", "TENANT" },
                    { "fe822c04-9838-4cf4-93d2-68af15916086", null, "Landlord", "LANDLORD" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a42387ec-4046-4438-9b45-e5811836fe33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af665deb-56f7-402d-960e-99780731bfe8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe822c04-9838-4cf4-93d2-68af15916086");

            migrationBuilder.DropColumn(
                name: "RealEstateId",
                table: "Requests");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2007a5fe-1056-40ee-b814-d1fd5f603703", null, "Tenant", "TENANT" },
                    { "6d368a31-d91f-444f-a7a8-bde2bd77636d", null, "Landlord", "LANDLORD" },
                    { "827a82d0-ce6a-4415-81e0-5bb1cf3d52d0", null, "Guest", "GUEST" }
                });
        }
    }
}
