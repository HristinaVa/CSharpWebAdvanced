using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindergartenSystem.Data.Migrations
{
    public partial class AddingImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("9a90a27c-37d2-4668-89d2-8475c8373fdc"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("8dafc948-2354-4128-b321-2bdeefd46a4c"));

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    KindergartenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Kindergartens_KindergartenId",
                        column: x => x.KindergartenId,
                        principalTable: "Kindergartens",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "ClassGroupId", "DateOfBirth", "FirstName", "ImageUrl", "LastName", "MiddleName", "ParentId" },
                values: new object[] { new Guid("0fc09785-f2b4-4955-91e2-3b1d8bb2064d"), 2, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "https://img.freepik.com/free-vector/cute-happy-smiling-child-isolated-white_1308-32243.jpg", "Iliev", "Hristov", new Guid("1af4589c-7297-4dbd-ad7d-bb275e8820b4") });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ClassGroupId", "EmailAddress", "ImageUrl", "Name", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("54fa7019-4756-425f-9eb4-e0ed17be0029"), 2, "ivanova.22@teacher.com", "https://st.depositphotos.com/1758000/2947/v/450/depositphotos_29477577-stock-illustration-eyewear-glasses-teacher-touching-chin.jpg", "Silviq Ivanova", "+359789000000", "4b72b514-00e0-4754-ab43-4c53199afbb8" });

            migrationBuilder.CreateIndex(
                name: "IX_Image_KindergartenId",
                table: "Image",
                column: "KindergartenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("0fc09785-f2b4-4955-91e2-3b1d8bb2064d"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("54fa7019-4756-425f-9eb4-e0ed17be0029"));

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "ClassGroupId", "DateOfBirth", "FirstName", "ImageUrl", "LastName", "MiddleName", "ParentId" },
                values: new object[] { new Guid("9a90a27c-37d2-4668-89d2-8475c8373fdc"), 2, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "https://img.freepik.com/free-vector/cute-happy-smiling-child-isolated-white_1308-32243.jpg", "Iliev", "Hristov", new Guid("1af4589c-7297-4dbd-ad7d-bb275e8820b4") });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ClassGroupId", "EmailAddress", "ImageUrl", "Name", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("8dafc948-2354-4128-b321-2bdeefd46a4c"), 2, "ivanova.22@teacher.com", "https://st.depositphotos.com/1758000/2947/v/450/depositphotos_29477577-stock-illustration-eyewear-glasses-teacher-touching-chin.jpg", "Silviq Ivanova", "+359789000000", "4b72b514-00e0-4754-ab43-4c53199afbb8" });
        }
    }
}
