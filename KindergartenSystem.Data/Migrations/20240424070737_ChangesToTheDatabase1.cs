using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindergartenSystem.Data.Migrations
{
    public partial class ChangesToTheDatabase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3b19d21b-6650-4ac3-926a-b5071b9a32b8", 0, "50029594-a854-49d3-ac11-e725009b9323", "username@user.com", false, "Katya", "Genova", false, null, "USERNAME@USER.COM", "USERNAME@USER.COM", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", null, false, "c3cdc956-7b1e-4c75-bf5d-1a383f696ffc", false, "username@user.com" });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "ClassGroupId", "DateOfBirth", "FirstName", "ImageUrl", "LastName", "MiddleName", "ParentId" },
                values: new object[] { new Guid("3796c123-7643-4f0a-ae98-0003d7bb9c53"), 2, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "https://img.freepik.com/free-vector/cute-happy-smiling-child-isolated-white_1308-32243.jpg", "Iliev", "Hristov", new Guid("3cbc521e-07d7-40e5-9d16-655769d51dff") });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "KindergartenId", "Url" },
                values: new object[,]
                {
                    { new Guid("056082e7-271d-430f-b0ef-a1023ed199d9"), 1, "https://as2.ftcdn.net/v2/jpg/05/95/07/45/1000_F_595074521_hpNDWQChd0dx3pKmFXoX6VNukn2PNOGz.jpg" },
                    { new Guid("0ae9c030-0559-4676-97f3-7610a92de666"), 1, "https://as2.ftcdn.net/v2/jpg/02/44/32/23/1000_F_244322317_eantlk9EzUZwcQ68xornkV4hxnGKz16T.jpg" },
                    { new Guid("bb7e0bb6-d710-4244-8711-09126e7022a5"), 1, "https://as1.ftcdn.net/v2/jpg/04/50/55/90/1000_F_450559026_CTK0vyFVr8d7ryOtZFrptDwT4mWP2IVf.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ClassGroupId", "EmailAddress", "ImageUrl", "Name", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("26f2d811-a225-45bb-b285-e9a2e5743bd2"), 1, "admin@admin.bg", "https://t4.ftcdn.net/jpg/04/75/00/99/360_F_475009987_zwsk4c77x3cTpcI3W1C1LU4pOSyPKaqi.jpg", "Admin Admin", "+359000000000", "bcb4f072-ecca-43c9-ab26-c060c6f364e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b19d21b-6650-4ac3-926a-b5071b9a32b8");

            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("3796c123-7643-4f0a-ae98-0003d7bb9c53"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("056082e7-271d-430f-b0ef-a1023ed199d9"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("0ae9c030-0559-4676-97f3-7610a92de666"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("bb7e0bb6-d710-4244-8711-09126e7022a5"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("26f2d811-a225-45bb-b285-e9a2e5743bd2"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c56dbbdd-4ce4-47d1-b622-84b5ec02b441", 0, "50029594-a854-49d3-ac11-e725009b9323", "username@user.com", false, "Katya", "Genova", false, null, "USERNAME@USER.COM", "USERNAME@USER.COM", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", null, false, "c3cdc956-7b1e-4c75-bf5d-1a383f696ffc", false, "username@user.com" });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "ClassGroupId", "DateOfBirth", "FirstName", "ImageUrl", "IsAttending", "IsKindergartener", "LastName", "MiddleName", "ParentId" },
                values: new object[] { new Guid("300c072f-e7a8-4704-a44c-4cd73e076308"), 2, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "https://img.freepik.com/free-vector/cute-happy-smiling-child-isolated-white_1308-32243.jpg", false, false, "Iliev", "Hristov", new Guid("3cbc521e-07d7-40e5-9d16-655769d51dff") });

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
                table: "Teachers",
                columns: new[] { "Id", "ClassGroupId", "EmailAddress", "ImageUrl", "IsWorking", "Name", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("ec3e8e85-00df-4a2a-858d-b7148e66161c"), 1, "admin@admin.bg", "https://t4.ftcdn.net/jpg/04/75/00/99/360_F_475009987_zwsk4c77x3cTpcI3W1C1LU4pOSyPKaqi.jpg", false, "Admin Admin", "+359000000000", "bcb4f072-ecca-43c9-ab26-c060c6f364e4" });
        }
    }
}
