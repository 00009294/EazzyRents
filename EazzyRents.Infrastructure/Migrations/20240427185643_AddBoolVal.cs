using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EazzyRents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBoolVal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "100d59d2-0438-4bdd-8192-ef8c0e1e552c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ca3b535-6ba1-47a1-88ac-95f7e2eafb4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94220910-f1df-49e6-b2ee-5e3bafbd20fd");

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
                    { "2e9262f9-95ba-46dd-a4f4-be263ee61413", null, "Guest", "GUEST" },
                    { "4996e9dd-e5a4-483a-8b3c-6d6a9dba5295", null, "Tenant", "TENANT" },
                    { "92156c8a-875f-4e6b-a385-cf982e972902", null, "Landlord", "LANDLORD" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsLandlord",
                table: "ChatMessages");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "100d59d2-0438-4bdd-8192-ef8c0e1e552c", null, "Tenant", "TENANT" },
                    { "3ca3b535-6ba1-47a1-88ac-95f7e2eafb4f", null, "Landlord", "LANDLORD" },
                    { "94220910-f1df-49e6-b2ee-5e3bafbd20fd", null, "Guest", "GUEST" }
                });
        }
    }
}
