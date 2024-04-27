using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EazzyRents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e9262f9-95ba-46dd-a4f4-be263ee61413");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4996e9dd-e5a4-483a-8b3c-6d6a9dba5295");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92156c8a-875f-4e6b-a385-cf982e972902");

            migrationBuilder.AddColumn<int>(
                name: "RealEstateId",
                table: "ChatMessages",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "RealEstateId",
                table: "ChatMessages");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e9262f9-95ba-46dd-a4f4-be263ee61413", null, "Guest", "GUEST" },
                    { "4996e9dd-e5a4-483a-8b3c-6d6a9dba5295", null, "Tenant", "TENANT" },
                    { "92156c8a-875f-4e6b-a385-cf982e972902", null, "Landlord", "LANDLORD" }
                });
        }
    }
}
