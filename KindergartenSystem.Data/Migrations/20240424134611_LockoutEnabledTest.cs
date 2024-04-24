using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindergartenSystem.Data.Migrations
{
    public partial class LockoutEnabledTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f264e4",
                column: "LockoutEnabled",
                value: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6d1f5e54-0d88-4c86-89b3-92b32c8070c3", 0, "50029594-a854-49d3-ac11-e725009b9323", "username@user.com", false, "Katya", "Genova", false, null, "USERNAME@USER.COM", "USERNAME@USER.COM", "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92", null, false, "C3CDC956-7B1E-4C75-BF5D-1A383F696FFC", false, "username@user.com" });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "ClassGroupId", "DateOfBirth", "FirstName", "ImageUrl", "LastName", "MiddleName", "ParentId" },
                values: new object[] { new Guid("71d5f2cc-76cc-4de1-8bf4-8b6d2bfa0c60"), 2, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "https://img.freepik.com/free-vector/cute-happy-smiling-child-isolated-white_1308-32243.jpg", "Iliev", "Hristov", new Guid("3cbc521e-07d7-40e5-9d16-655769d51dff") });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "KindergartenId", "Url" },
                values: new object[,]
                {
                    { new Guid("0909894a-7f7c-4f06-aff5-450c2f24dc09"), 1, "https://as2.ftcdn.net/v2/jpg/02/44/32/23/1000_F_244322317_eantlk9EzUZwcQ68xornkV4hxnGKz16T.jpg" },
                    { new Guid("91dd53ba-73b8-47b0-ba5b-4ead76778729"), 1, "https://as2.ftcdn.net/v2/jpg/05/95/07/45/1000_F_595074521_hpNDWQChd0dx3pKmFXoX6VNukn2PNOGz.jpg" },
                    { new Guid("e066d3c3-73f1-4990-9e08-7994bd7a2c7e"), 1, "https://as1.ftcdn.net/v2/jpg/04/50/55/90/1000_F_450559026_CTK0vyFVr8d7ryOtZFrptDwT4mWP2IVf.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ClassGroupId", "EmailAddress", "ImageUrl", "Name", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("43c50b97-9c66-4556-b703-7a0734ce389d"), 1, "admin@admin.bg", "https://t4.ftcdn.net/jpg/04/75/00/99/360_F_475009987_zwsk4c77x3cTpcI3W1C1LU4pOSyPKaqi.jpg", "Admin Admin", "+359000000000", "bcb4f072-ecca-43c9-ab26-c060c6f264e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d1f5e54-0d88-4c86-89b3-92b32c8070c3");

            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("71d5f2cc-76cc-4de1-8bf4-8b6d2bfa0c60"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("0909894a-7f7c-4f06-aff5-450c2f24dc09"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("91dd53ba-73b8-47b0-ba5b-4ead76778729"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("e066d3c3-73f1-4990-9e08-7994bd7a2c7e"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("43c50b97-9c66-4556-b703-7a0734ce389d"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f264e4",
                column: "LockoutEnabled",
                value: false);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "15be12f3-74c3-4b14-a2b6-cd2c487cab4c", 0, "50029594-a854-49d3-ac11-e725009b9323", "username@user.com", false, "Katya", "Genova", false, null, "USERNAME@USER.COM", "USERNAME@USER.COM", "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92", null, false, "C3CDC956-7B1E-4C75-BF5D-1A383F696FFC", false, "username@user.com" });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "ClassGroupId", "DateOfBirth", "FirstName", "ImageUrl", "IsAttending", "IsKindergartener", "LastName", "MiddleName", "ParentId" },
                values: new object[] { new Guid("c304a362-51b3-42ba-9cc0-ffcdff145244"), 2, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "https://img.freepik.com/free-vector/cute-happy-smiling-child-isolated-white_1308-32243.jpg", false, false, "Iliev", "Hristov", new Guid("3cbc521e-07d7-40e5-9d16-655769d51dff") });

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
                columns: new[] { "Id", "ClassGroupId", "EmailAddress", "ImageUrl", "IsWorking", "Name", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("65a024a3-bc83-40d0-be77-412692300ee8"), 1, "admin@admin.bg", "https://t4.ftcdn.net/jpg/04/75/00/99/360_F_475009987_zwsk4c77x3cTpcI3W1C1LU4pOSyPKaqi.jpg", false, "Admin Admin", "+359000000000", "bcb4f072-ecca-43c9-ab26-c060c6f264e4" });
        }
    }
}
