using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindergartenSystem.Data.Migrations
{
    public partial class SeedingImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Kindergartens_KindergartenId",
                table: "Image");

            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("0fc09785-f2b4-4955-91e2-3b1d8bb2064d"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("54fa7019-4756-425f-9eb4-e0ed17be0029"));

            migrationBuilder.AlterColumn<int>(
                name: "KindergartenId",
                table: "Image",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "ClassGroupId", "DateOfBirth", "FirstName", "ImageUrl", "LastName", "MiddleName", "ParentId" },
                values: new object[] { new Guid("d67fdaf3-16bd-4105-b122-70699467873b"), 2, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "https://img.freepik.com/free-vector/cute-happy-smiling-child-isolated-white_1308-32243.jpg", "Iliev", "Hristov", new Guid("1af4589c-7297-4dbd-ad7d-bb275e8820b4") });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "KindergartenId", "Url" },
                values: new object[,]
                {
                    { new Guid("156bc2bf-bd0a-4d4c-a3e4-e645c4e044eb"), 1, "https://landezine.com/wp-content/uploads/2023/06/13-3-1270x846.jpg" },
                    { new Guid("4c05cf0c-c5af-4f75-a0b9-8f34576a77be"), 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTaUwQTx7J17GWtmvOuoaecCfBw7c-sUmOTk1xjm0IQQxjR2CZH0154QwUT103frsZBezI&usqp=CAU" },
                    { new Guid("c3964289-b53e-415f-85a9-f033a294afb5"), 1, "https://file2.okorder.com/attach/2017/01/09/b6e37ea332d65dca1d4172df440fcc72.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ClassGroupId", "EmailAddress", "ImageUrl", "Name", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("db33cdbf-30b0-452e-b16d-de56d4555fa0"), 2, "ivanova.22@teacher.com", "https://st.depositphotos.com/1758000/2947/v/450/depositphotos_29477577-stock-illustration-eyewear-glasses-teacher-touching-chin.jpg", "Silviq Ivanova", "+359789000000", "4b72b514-00e0-4754-ab43-4c53199afbb8" });

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Kindergartens_KindergartenId",
                table: "Image",
                column: "KindergartenId",
                principalTable: "Kindergartens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Kindergartens_KindergartenId",
                table: "Image");

            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("d67fdaf3-16bd-4105-b122-70699467873b"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("156bc2bf-bd0a-4d4c-a3e4-e645c4e044eb"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("4c05cf0c-c5af-4f75-a0b9-8f34576a77be"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("c3964289-b53e-415f-85a9-f033a294afb5"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("db33cdbf-30b0-452e-b16d-de56d4555fa0"));

            migrationBuilder.AlterColumn<int>(
                name: "KindergartenId",
                table: "Image",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "ClassGroupId", "DateOfBirth", "FirstName", "ImageUrl", "LastName", "MiddleName", "ParentId" },
                values: new object[] { new Guid("0fc09785-f2b4-4955-91e2-3b1d8bb2064d"), 2, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "https://img.freepik.com/free-vector/cute-happy-smiling-child-isolated-white_1308-32243.jpg", "Iliev", "Hristov", new Guid("1af4589c-7297-4dbd-ad7d-bb275e8820b4") });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ClassGroupId", "EmailAddress", "ImageUrl", "Name", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("54fa7019-4756-425f-9eb4-e0ed17be0029"), 2, "ivanova.22@teacher.com", "https://st.depositphotos.com/1758000/2947/v/450/depositphotos_29477577-stock-illustration-eyewear-glasses-teacher-touching-chin.jpg", "Silviq Ivanova", "+359789000000", "4b72b514-00e0-4754-ab43-4c53199afbb8" });

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Kindergartens_KindergartenId",
                table: "Image",
                column: "KindergartenId",
                principalTable: "Kindergartens",
                principalColumn: "Id");
        }
    }
}
