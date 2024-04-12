using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EazzyRents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "requestStatus",
                table: "Requests",
                newName: "RequestStatus");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Requests",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmittedDate",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20a129b0-98d7-4fd2-8670-22f3a1c01bab", null, "Guest", "GUEST" },
                    { "7cfb22e6-77fb-4362-b1c2-b9d690a7445b", null, "Tenant", "TENANT" },
                    { "8cfb06ea-8d31-425d-8bd4-c2ffe5125f7f", null, "Landlord", "LANDLORD" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20a129b0-98d7-4fd2-8670-22f3a1c01bab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cfb22e6-77fb-4362-b1c2-b9d690a7445b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cfb06ea-8d31-425d-8bd4-c2ffe5125f7f");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "SubmittedDate",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "RequestStatus",
                table: "Requests",
                newName: "requestStatus");

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
    }
}
