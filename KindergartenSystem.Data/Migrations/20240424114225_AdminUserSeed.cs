using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindergartenSystem.Data.Migrations
{
    public partial class AdminUserSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "81526e9b-b638-44a1-b3bf-03aa5d0cde3d", 0, "50029594-a854-49d3-ac11-e725009b9323", "username@user.com", false, "Katya", "Genova", false, null, "USERNAME@USER.COM", "USERNAME@USER.COM", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", null, false, "c3cdc956-7b1e-4c75-bf5d-1a383f696ffc", false, "username@user.com" },
                    { "bcb4f072-ecca-43c9-ab26-c060c6f264e4", 0, "50029594-a854-49d3-ac11-e725009b9327", "admin@admin.bg", false, "Admin", "Admin", false, null, "ADMIN@ADMIN.BG", "ADMIN@ADMIN.BG", "6F741B93409297B6B3BE618073B5F5899793CB18DDB45274FE6A636B1C62393A", null, false, "C3CDC956-7B1E-4C75-BF5D-1A383F696FFB", false, "admin@admin.bg" }
                });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "ClassGroupId", "DateOfBirth", "FirstName", "ImageUrl", "LastName", "MiddleName", "ParentId" },
                values: new object[] { new Guid("0908674c-1f66-41c1-85ad-6ccaf523610b"), 2, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "https://img.freepik.com/free-vector/cute-happy-smiling-child-isolated-white_1308-32243.jpg", "Iliev", "Hristov", new Guid("3cbc521e-07d7-40e5-9d16-655769d51dff") });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "KindergartenId", "Url" },
                values: new object[,]
                {
                    { new Guid("4524f386-bc58-4672-ac17-37030f8bc858"), 1, "https://as1.ftcdn.net/v2/jpg/04/50/55/90/1000_F_450559026_CTK0vyFVr8d7ryOtZFrptDwT4mWP2IVf.jpg" },
                    { new Guid("508170ad-6737-400a-8b32-70022d5aae0d"), 1, "https://as2.ftcdn.net/v2/jpg/05/95/07/45/1000_F_595074521_hpNDWQChd0dx3pKmFXoX6VNukn2PNOGz.jpg" },
                    { new Guid("5607195a-d1bb-4970-905d-ba43dddd9ff4"), 1, "https://as2.ftcdn.net/v2/jpg/02/44/32/23/1000_F_244322317_eantlk9EzUZwcQ68xornkV4hxnGKz16T.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ClassGroupId", "EmailAddress", "ImageUrl", "Name", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("4a64c067-084c-42ae-a32b-df8a162091b3"), 1, "admin@admin.bg", "https://t4.ftcdn.net/jpg/04/75/00/99/360_F_475009987_zwsk4c77x3cTpcI3W1C1LU4pOSyPKaqi.jpg", "Admin Admin", "+359000000000", "bcb4f072-ecca-43c9-ab26-c060c6f264e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81526e9b-b638-44a1-b3bf-03aa5d0cde3d");

            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("0908674c-1f66-41c1-85ad-6ccaf523610b"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("4524f386-bc58-4672-ac17-37030f8bc858"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("508170ad-6737-400a-8b32-70022d5aae0d"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("5607195a-d1bb-4970-905d-ba43dddd9ff4"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("4a64c067-084c-42ae-a32b-df8a162091b3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f264e4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3b19d21b-6650-4ac3-926a-b5071b9a32b8", 0, "50029594-a854-49d3-ac11-e725009b9323", "username@user.com", false, "Katya", "Genova", false, null, "USERNAME@USER.COM", "USERNAME@USER.COM", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", null, false, "c3cdc956-7b1e-4c75-bf5d-1a383f696ffc", false, "username@user.com" },
                    { "bcb4f072-ecca-43c9-ab26-c060c6f364e4", 0, "50029594-a854-49d3-ac11-e725009b9327", "admin@admin.bg", false, "Admin", "Admin", false, null, "ADMIN@ADMIN.BG", "ADMIN@ADMIN.BG", "cf03042ca45f3cbff74bffadc0baead9cd92d4a8a8a574fbd2dd353ae78a378c", null, false, "c3cdc956-7b1e-4c75-bf5d-1a383f696ffb", false, "admin@admin.bg" }
                });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "ClassGroupId", "DateOfBirth", "FirstName", "ImageUrl", "IsAttending", "IsKindergartener", "LastName", "MiddleName", "ParentId" },
                values: new object[] { new Guid("3796c123-7643-4f0a-ae98-0003d7bb9c53"), 2, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "https://img.freepik.com/free-vector/cute-happy-smiling-child-isolated-white_1308-32243.jpg", false, false, "Iliev", "Hristov", new Guid("3cbc521e-07d7-40e5-9d16-655769d51dff") });

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
                columns: new[] { "Id", "ClassGroupId", "EmailAddress", "ImageUrl", "IsWorking", "Name", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("26f2d811-a225-45bb-b285-e9a2e5743bd2"), 1, "admin@admin.bg", "https://t4.ftcdn.net/jpg/04/75/00/99/360_F_475009987_zwsk4c77x3cTpcI3W1C1LU4pOSyPKaqi.jpg", false, "Admin Admin", "+359000000000", "bcb4f072-ecca-43c9-ab26-c060c6f364e4" });
        }
    }
}
