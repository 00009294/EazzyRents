using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EazzyRents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailToImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac0e3dce-a599-444e-adbd-707af65ee9b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3cb1957-ba12-47ac-98e9-ed1af084ec07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5b653bc-a60c-4d83-aafb-19d89f5e1895");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "235e4939-ca1f-4dfe-a9be-24be8e619d60", null, "Guest", "GUEST" },
                    { "57487993-2294-4907-80e2-441525388b85", null, "Landlord", "LANDLORD" },
                    { "d8457c89-4990-42b7-b27a-a87baa177dc9", null, "Tenant", "TENANT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "235e4939-ca1f-4dfe-a9be-24be8e619d60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57487993-2294-4907-80e2-441525388b85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8457c89-4990-42b7-b27a-a87baa177dc9");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Images");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ac0e3dce-a599-444e-adbd-707af65ee9b9", null, "Landlord", "LANDLORD" },
                    { "e3cb1957-ba12-47ac-98e9-ed1af084ec07", null, "Tenant", "TENANT" },
                    { "f5b653bc-a60c-4d83-aafb-19d89f5e1895", null, "Guest", "GUEST" }
                });
        }
    }
}
