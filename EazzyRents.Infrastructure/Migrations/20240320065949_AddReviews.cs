using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EazzyRents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74cf3714-6936-4b64-a277-806c0c5f0d4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87d92a6d-a6b7-4a42-a99b-ee52f19ef0d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97446ca4-f6fa-4372-99c1-99f9645bf6fb");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "RatingAndReviews");

            migrationBuilder.DropColumn(
                name: "RealEstateId",
                table: "RatingAndReviews");

            migrationBuilder.CreateTable(
                name: "RealEstateRatingAndReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    ReviewMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RealEstateId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateRatingAndReviews", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealEstateRatingAndReviews");

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

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "RatingAndReviews",
                type: "nvarchar(34)",
                maxLength: 34,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RealEstateId",
                table: "RatingAndReviews",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "74cf3714-6936-4b64-a277-806c0c5f0d4f", null, "Landlord", "LANDLORD" },
                    { "87d92a6d-a6b7-4a42-a99b-ee52f19ef0d0", null, "Tenant", "TENANT" },
                    { "97446ca4-f6fa-4372-99c1-99f9645bf6fb", null, "Guest", "GUEST" }
                });
        }
    }
}
