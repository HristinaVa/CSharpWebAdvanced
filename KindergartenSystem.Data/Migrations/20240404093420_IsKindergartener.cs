using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindergartenSystem.Data.Migrations
{
    public partial class IsKindergartener : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<bool>(
                name: "IsKindergartener",
                table: "Children",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "ClassGroupId", "DateOfBirth", "FirstName", "ImageUrl", "LastName", "MiddleName", "ParentId" },
                values: new object[] { new Guid("91398b12-d4f5-4e70-a029-2e7e64dc283f"), 2, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "https://img.freepik.com/free-vector/cute-happy-smiling-child-isolated-white_1308-32243.jpg", "Iliev", "Hristov", new Guid("1af4589c-7297-4dbd-ad7d-bb275e8820b4") });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "KindergartenId", "Url" },
                values: new object[,]
                {
                    { new Guid("2ad9f36d-7964-4004-86b4-b3e7a42073d3"), 1, "https://file2.okorder.com/attach/2017/01/09/b6e37ea332d65dca1d4172df440fcc72.jpg" },
                    { new Guid("4adbbe83-1e88-49ff-b6b1-3806d587e6bc"), 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTaUwQTx7J17GWtmvOuoaecCfBw7c-sUmOTk1xjm0IQQxjR2CZH0154QwUT103frsZBezI&usqp=CAU" },
                    { new Guid("63e977a7-ab00-439b-aea7-6c19ae0c0441"), 1, "https://landezine.com/wp-content/uploads/2023/06/13-3-1270x846.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ClassGroupId", "EmailAddress", "ImageUrl", "Name", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("62720c0d-c8cd-4d4b-af81-6c565ff37e36"), 2, "ivanova.22@teacher.com", "https://st.depositphotos.com/1758000/2947/v/450/depositphotos_29477577-stock-illustration-eyewear-glasses-teacher-touching-chin.jpg", "Silviq Ivanova", "+359789000000", "4b72b514-00e0-4754-ab43-4c53199afbb8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("91398b12-d4f5-4e70-a029-2e7e64dc283f"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("2ad9f36d-7964-4004-86b4-b3e7a42073d3"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("4adbbe83-1e88-49ff-b6b1-3806d587e6bc"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("63e977a7-ab00-439b-aea7-6c19ae0c0441"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("62720c0d-c8cd-4d4b-af81-6c565ff37e36"));

            migrationBuilder.DropColumn(
                name: "IsKindergartener",
                table: "Children");

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
        }
    }
}
