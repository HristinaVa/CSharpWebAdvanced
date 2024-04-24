using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindergartenSystem.Data.Migrations
{
    public partial class ChangesToTheDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("889693a6-6d30-42f1-a990-6f45e5e19ae8"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("716af213-6aaf-4fac-8389-835c79ac4904"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("ae2a7e15-5818-430e-8a15-c278efd80cda"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("facff116-d379-4f98-b065-a26454814e00"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("380ab57f-889d-414e-8e6d-e5521afb58ce"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("ad92d28d-8cb6-45a0-beb4-40726a822f52"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "bcb4f072-ecca-43c9-ab26-c060c6f364e3", 0, "50029594-a854-49d3-ac11-e725009b9326", "userparent@user.com", false, "Iva", "Ilieva", false, null, "USERPARENT@USER.COM", "USERPARENT@USER.COM", "e150a1ec81e8e93e1eae2c3a77e66ec6dbd6a3b460f89c1d08aecf422ee401a0", null, false, "c3cdc956-7b1e-4c75-bf5d-1a383f696ffa", false, "userparent@user.com" },
                    { "bcb4f072-ecca-43c9-ab26-c060c6f364e4", 0, "50029594-a854-49d3-ac11-e725009b9327", "admin@admin.bg", false, "Admin", "Admin", false, null, "ADMIN@ADMIN.BG", "ADMIN@ADMIN.BG", "cf03042ca45f3cbff74bffadc0baead9cd92d4a8a8a574fbd2dd353ae78a378c", null, false, "c3cdc956-7b1e-4c75-bf5d-1a383f696ffb", false, "admin@admin.bg" },
                    { "c56dbbdd-4ce4-47d1-b622-84b5ec02b441", 0, "50029594-a854-49d3-ac11-e725009b9323", "username@user.com", false, "Katya", "Genova", false, null, "USERNAME@USER.COM", "USERNAME@USER.COM", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", null, false, "c3cdc956-7b1e-4c75-bf5d-1a383f696ffc", false, "username@user.com" }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "KindergartenId", "Url" },
                values: new object[,]
                {
                    { new Guid("1d72b9fb-09e2-4f46-b3b0-3dec9062dda2"), 1, "https://as2.ftcdn.net/v2/jpg/02/44/32/23/1000_F_244322317_eantlk9EzUZwcQ68xornkV4hxnGKz16T.jpg" },
                    { new Guid("2cbca7fc-6a55-42e8-b894-92242823d8b8"), 1, "https://as1.ftcdn.net/v2/jpg/04/50/55/90/1000_F_450559026_CTK0vyFVr8d7ryOtZFrptDwT4mWP2IVf.jpg" },
                    { new Guid("5548d8d6-f20f-4a99-aa33-a89b8c8db1e6"), 1, "https://as2.ftcdn.net/v2/jpg/05/95/07/45/1000_F_595074521_hpNDWQChd0dx3pKmFXoX6VNukn2PNOGz.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "Id", "Address", "EmailAddress", "Name", "PhoneNumber", "Status", "UserId" },
                values: new object[] { new Guid("3cbc521e-07d7-40e5-9d16-655769d51dff"), "ul.Morska 12", "userparent@user.com", "Iva Ilieva", "+359878888881", 1, "bcb4f072-ecca-43c9-ab26-c060c6f364e3" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ClassGroupId", "EmailAddress", "ImageUrl", "Name", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("ec3e8e85-00df-4a2a-858d-b7148e66161c"), 1, "admin@admin.bg", "https://t4.ftcdn.net/jpg/04/75/00/99/360_F_475009987_zwsk4c77x3cTpcI3W1C1LU4pOSyPKaqi.jpg", "Admin Admin", "+359000000000", "bcb4f072-ecca-43c9-ab26-c060c6f364e4" });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "ClassGroupId", "DateOfBirth", "FirstName", "ImageUrl", "LastName", "MiddleName", "ParentId" },
                values: new object[] { new Guid("300c072f-e7a8-4704-a44c-4cd73e076308"), 2, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "https://img.freepik.com/free-vector/cute-happy-smiling-child-isolated-white_1308-32243.jpg", "Iliev", "Hristov", new Guid("3cbc521e-07d7-40e5-9d16-655769d51dff") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c56dbbdd-4ce4-47d1-b622-84b5ec02b441");

            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("300c072f-e7a8-4704-a44c-4cd73e076308"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("1d72b9fb-09e2-4f46-b3b0-3dec9062dda2"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("2cbca7fc-6a55-42e8-b894-92242823d8b8"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("5548d8d6-f20f-4a99-aa33-a89b8c8db1e6"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("ec3e8e85-00df-4a2a-858d-b7148e66161c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4");

            migrationBuilder.DeleteData(
                table: "Parents",
                keyColumn: "Id",
                keyValue: new Guid("3cbc521e-07d7-40e5-9d16-655769d51dff"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e3");

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "ClassGroupId", "DateOfBirth", "FirstName", "ImageUrl", "IsAttending", "IsKindergartener", "LastName", "MiddleName", "ParentId" },
                values: new object[] { new Guid("889693a6-6d30-42f1-a990-6f45e5e19ae8"), 2, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "https://img.freepik.com/free-vector/cute-happy-smiling-child-isolated-white_1308-32243.jpg", false, false, "Iliev", "Hristov", new Guid("1af4589c-7297-4dbd-ad7d-bb275e8820b4") });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "KindergartenId", "Url" },
                values: new object[,]
                {
                    { new Guid("716af213-6aaf-4fac-8389-835c79ac4904"), 1, "https://landezine.com/wp-content/uploads/2023/06/13-3-1270x846.jpg" },
                    { new Guid("ae2a7e15-5818-430e-8a15-c278efd80cda"), 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTaUwQTx7J17GWtmvOuoaecCfBw7c-sUmOTk1xjm0IQQxjR2CZH0154QwUT103frsZBezI&usqp=CAU" },
                    { new Guid("facff116-d379-4f98-b065-a26454814e00"), 1, "https://file2.okorder.com/attach/2017/01/09/b6e37ea332d65dca1d4172df440fcc72.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ClassGroupId", "EmailAddress", "ImageUrl", "IsWorking", "Name", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { new Guid("380ab57f-889d-414e-8e6d-e5521afb58ce"), 1, "admin@admin.bg", "https://t4.ftcdn.net/jpg/04/75/00/99/360_F_475009987_zwsk4c77x3cTpcI3W1C1LU4pOSyPKaqi.jpg", false, "Admin Admin", "+359000000000", "1605dfd0-0033-408e-aae7-ca088e86985d" },
                    { new Guid("ad92d28d-8cb6-45a0-beb4-40726a822f52"), 2, "ivanova.22@teacher.com", "https://st.depositphotos.com/1758000/2947/v/450/depositphotos_29477577-stock-illustration-eyewear-glasses-teacher-touching-chin.jpg", false, "Silviq Ivanova", "+359789000000", "4b72b514-00e0-4754-ab43-4c53199afbb8" }
                });
        }
    }
}
