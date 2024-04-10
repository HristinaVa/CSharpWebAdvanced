using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindergartenSystem.Data.Migrations
{
    public partial class applicationuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("04321b30-62a5-4798-9654-d6d5cd29c542"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("4472f834-77f8-45a4-984d-8b4e4b3cc01c"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("545d6eeb-df2f-4832-ac5d-5319bc12bff2"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("f235cf00-b11f-4fbd-afe2-a5b3fcd768be"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("887fdfd3-d476-4407-b16b-9305b105b830"));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "...");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "...");

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "ClassGroupId", "DateOfBirth", "FirstName", "ImageUrl", "LastName", "MiddleName", "ParentId" },
                values: new object[] { new Guid("87d13ec6-5ff0-4383-bac5-82e83e18cbfb"), 2, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "https://img.freepik.com/free-vector/cute-happy-smiling-child-isolated-white_1308-32243.jpg", "Iliev", "Hristov", new Guid("1af4589c-7297-4dbd-ad7d-bb275e8820b4") });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "KindergartenId", "Url" },
                values: new object[,]
                {
                    { new Guid("95d9631b-1e88-4aaa-9b13-98740644fd5c"), 1, "https://landezine.com/wp-content/uploads/2023/06/13-3-1270x846.jpg" },
                    { new Guid("ac7f1d45-7a2e-4a68-8b7a-321ecff2fcf7"), 1, "https://file2.okorder.com/attach/2017/01/09/b6e37ea332d65dca1d4172df440fcc72.jpg" },
                    { new Guid("e4dbee5c-5cc9-42f2-b1cb-b988246ce934"), 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTaUwQTx7J17GWtmvOuoaecCfBw7c-sUmOTk1xjm0IQQxjR2CZH0154QwUT103frsZBezI&usqp=CAU" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ClassGroupId", "EmailAddress", "ImageUrl", "Name", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("47082bc6-2fb0-43de-8ed8-89eeae939756"), 2, "ivanova.22@teacher.com", "https://st.depositphotos.com/1758000/2947/v/450/depositphotos_29477577-stock-illustration-eyewear-glasses-teacher-touching-chin.jpg", "Silviq Ivanova", "+359789000000", "4b72b514-00e0-4754-ab43-4c53199afbb8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("87d13ec6-5ff0-4383-bac5-82e83e18cbfb"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("95d9631b-1e88-4aaa-9b13-98740644fd5c"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("ac7f1d45-7a2e-4a68-8b7a-321ecff2fcf7"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("e4dbee5c-5cc9-42f2-b1cb-b988246ce934"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("47082bc6-2fb0-43de-8ed8-89eeae939756"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "ClassGroupId", "DateOfBirth", "FirstName", "ImageUrl", "IsAttending", "IsKindergartener", "LastName", "MiddleName", "ParentId" },
                values: new object[] { new Guid("04321b30-62a5-4798-9654-d6d5cd29c542"), 2, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "https://img.freepik.com/free-vector/cute-happy-smiling-child-isolated-white_1308-32243.jpg", false, false, "Iliev", "Hristov", new Guid("1af4589c-7297-4dbd-ad7d-bb275e8820b4") });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "KindergartenId", "Url" },
                values: new object[,]
                {
                    { new Guid("4472f834-77f8-45a4-984d-8b4e4b3cc01c"), 1, "https://file2.okorder.com/attach/2017/01/09/b6e37ea332d65dca1d4172df440fcc72.jpg" },
                    { new Guid("545d6eeb-df2f-4832-ac5d-5319bc12bff2"), 1, "https://landezine.com/wp-content/uploads/2023/06/13-3-1270x846.jpg" },
                    { new Guid("f235cf00-b11f-4fbd-afe2-a5b3fcd768be"), 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTaUwQTx7J17GWtmvOuoaecCfBw7c-sUmOTk1xjm0IQQxjR2CZH0154QwUT103frsZBezI&usqp=CAU" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ClassGroupId", "EmailAddress", "ImageUrl", "Name", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("887fdfd3-d476-4407-b16b-9305b105b830"), 2, "ivanova.22@teacher.com", "https://st.depositphotos.com/1758000/2947/v/450/depositphotos_29477577-stock-illustration-eyewear-glasses-teacher-touching-chin.jpg", "Silviq Ivanova", "+359789000000", "4b72b514-00e0-4754-ab43-4c53199afbb8" });
        }
    }
}
