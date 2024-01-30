using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EazzyRents.Infrastructure.Migrations
{
      /// <inheritdoc />
      public partial class AddBlobModel : Migration
      {
            /// <inheritdoc />
            protected override void Up (MigrationBuilder migrationBuilder)
            {
                  migrationBuilder.DeleteData(
                      table: "AspNetRoles",
                      keyColumn: "Id",
                      keyValue: "35638662-29f0-45a8-a228-40bcf644dfd1");

                  migrationBuilder.DeleteData(
                      table: "AspNetRoles",
                      keyColumn: "Id",
                      keyValue: "35a1ce92-8d31-42e4-aced-f8f4a88fef5e");

                  migrationBuilder.DeleteData(
                      table: "AspNetRoles",
                      keyColumn: "Id",
                      keyValue: "43500a5f-9bab-4948-88ee-66195d1d4dca");

                  migrationBuilder.AddColumn<string>(
                      name: "Path",
                      table: "Images",
                      type: "nvarchar(max)",
                      nullable: false,
                      defaultValue: "");

                  migrationBuilder.InsertData(
                      table: "AspNetRoles",
                      columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                      values: new object[,]
                      {
                    { "0d81c1ef-d16f-4ce9-a1bf-05d7e4bc15fc", null, "Tenant", "TENANT" },
                    { "61e202b0-bb29-47d3-a34d-a660393e52ad", null, "Landlord", "LANDLORD" },
                    { "b63d097c-4c5c-4d34-87c9-3d06cec8fbae", null, "Guest", "GUEST" }
                      });
            }

            /// <inheritdoc />
            protected override void Down (MigrationBuilder migrationBuilder)
            {
                  migrationBuilder.DeleteData(
                      table: "AspNetRoles",
                      keyColumn: "Id",
                      keyValue: "0d81c1ef-d16f-4ce9-a1bf-05d7e4bc15fc");

                  migrationBuilder.DeleteData(
                      table: "AspNetRoles",
                      keyColumn: "Id",
                      keyValue: "61e202b0-bb29-47d3-a34d-a660393e52ad");

                  migrationBuilder.DeleteData(
                      table: "AspNetRoles",
                      keyColumn: "Id",
                      keyValue: "b63d097c-4c5c-4d34-87c9-3d06cec8fbae");

                  migrationBuilder.DropColumn(
                      name: "Path",
                      table: "Images");

                  migrationBuilder.InsertData(
                      table: "AspNetRoles",
                      columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                      values: new object[,]
                      {
                    { "35638662-29f0-45a8-a228-40bcf644dfd1", null, "Tenant", "TENANT" },
                    { "35a1ce92-8d31-42e4-aced-f8f4a88fef5e", null, "Guest", "GUEST" },
                    { "43500a5f-9bab-4948-88ee-66195d1d4dca", null, "Landlord", "LANDLORD" }
                      });
            }
      }
}
