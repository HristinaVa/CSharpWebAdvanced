using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindergartenSystem.Data.Migrations
{
    public partial class PasswordHashToUpper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e3",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "E150A1EC81E8E93E1EAE2C3A77E66EC6DBD6A3B460F89C1D08AECF422EE401A0", "C3CDC956-7B1E-4C75-BF5D-1A383F696FFA" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "15be12f3-74c3-4b14-a2b6-cd2c487cab4c", 0, "50029594-a854-49d3-ac11-e725009b9323", "username@user.com", false, "Katya", "Genova", false, null, "USERNAME@USER.COM", "USERNAME@USER.COM", "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92", null, false, "C3CDC956-7B1E-4C75-BF5D-1A383F696FFC", false, "username@user.com" });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "ClassGroupId", "DateOfBirth", "FirstName", "ImageUrl", "LastName", "MiddleName", "ParentId" },
                values: new object[] { new Guid("c304a362-51b3-42ba-9cc0-ffcdff145244"), 2, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "https://img.freepik.com/free-vector/cute-happy-smiling-child-isolated-white_1308-32243.jpg", "Iliev", "Hristov", new Guid("3cbc521e-07d7-40e5-9d16-655769d51dff") });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "KindergartenId", "Url" },
                values: new object[,]
                {
                    { new Guid("c39204df-ad09-416b-9897-4e01065e9027"), 1, "https://as1.ftcdn.net/v2/jpg/04/50/55/90/1000_F_450559026_CTK0vyFVr8d7ryOtZFrptDwT4mWP2IVf.jpg" },
                    { new Guid("d67089ff-a4d1-49a7-85b6-091c5931893e"), 1, "https://as2.ftcdn.net/v2/jpg/02/44/32/23/1000_F_244322317_eantlk9EzUZwcQ68xornkV4hxnGKz16T.jpg" },
                    { new Guid("f147420e-bfe3-4d8a-84ee-a4c2797a3059"), 1, "https://as2.ftcdn.net/v2/jpg/05/95/07/45/1000_F_595074521_hpNDWQChd0dx3pKmFXoX6VNukn2PNOGz.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ClassGroupId", "EmailAddress", "ImageUrl", "Name", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("65a024a3-bc83-40d0-be77-412692300ee8"), 1, "admin@admin.bg", "https://t4.ftcdn.net/jpg/04/75/00/99/360_F_475009987_zwsk4c77x3cTpcI3W1C1LU4pOSyPKaqi.jpg", "Admin Admin", "+359000000000", "bcb4f072-ecca-43c9-ab26-c060c6f264e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15be12f3-74c3-4b14-a2b6-cd2c487cab4c");

            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("c304a362-51b3-42ba-9cc0-ffcdff145244"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("c39204df-ad09-416b-9897-4e01065e9027"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("d67089ff-a4d1-49a7-85b6-091c5931893e"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("f147420e-bfe3-4d8a-84ee-a4c2797a3059"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("65a024a3-bc83-40d0-be77-412692300ee8"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e3",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "e150a1ec81e8e93e1eae2c3a77e66ec6dbd6a3b460f89c1d08aecf422ee401a0", "c3cdc956-7b1e-4c75-bf5d-1a383f696ffa" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "81526e9b-b638-44a1-b3bf-03aa5d0cde3d", 0, "50029594-a854-49d3-ac11-e725009b9323", "username@user.com", false, "Katya", "Genova", false, null, "USERNAME@USER.COM", "USERNAME@USER.COM", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", null, false, "c3cdc956-7b1e-4c75-bf5d-1a383f696ffc", false, "username@user.com" });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "ClassGroupId", "DateOfBirth", "FirstName", "ImageUrl", "IsAttending", "IsKindergartener", "LastName", "MiddleName", "ParentId" },
                values: new object[] { new Guid("0908674c-1f66-41c1-85ad-6ccaf523610b"), 2, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "https://img.freepik.com/free-vector/cute-happy-smiling-child-isolated-white_1308-32243.jpg", false, false, "Iliev", "Hristov", new Guid("3cbc521e-07d7-40e5-9d16-655769d51dff") });

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
                columns: new[] { "Id", "ClassGroupId", "EmailAddress", "ImageUrl", "IsWorking", "Name", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("4a64c067-084c-42ae-a32b-df8a162091b3"), 1, "admin@admin.bg", "https://t4.ftcdn.net/jpg/04/75/00/99/360_F_475009987_zwsk4c77x3cTpcI3W1C1LU4pOSyPKaqi.jpg", false, "Admin Admin", "+359000000000", "bcb4f072-ecca-43c9-ab26-c060c6f264e4" });
        }
    }
}
