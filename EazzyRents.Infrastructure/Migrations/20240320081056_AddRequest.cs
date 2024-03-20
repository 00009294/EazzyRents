using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EazzyRents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0974db5a-be6b-48f5-be94-7be939557d47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f0c927b-1afa-4fd6-9bdb-84f509d92392");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84ee810d-4cfc-4345-a89b-4a0b2e2da24f");

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    LandlordId = table.Column<int>(type: "int", nullable: false),
                    requestStatus = table.Column<int>(type: "int", nullable: false),
                    MoveInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoveOutDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0974db5a-be6b-48f5-be94-7be939557d47", null, "Landlord", "LANDLORD" },
                    { "4f0c927b-1afa-4fd6-9bdb-84f509d92392", null, "Tenant", "TENANT" },
                    { "84ee810d-4cfc-4345-a89b-4a0b2e2da24f", null, "Guest", "GUEST" }
                });
        }
    }
}
