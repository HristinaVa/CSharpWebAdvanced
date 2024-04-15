using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindergartenSystem.Data.Migrations
{
    public partial class emailAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("828bc370-17a6-4b60-95e8-663fca82ce5b"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("51ed67bb-ace0-428c-bcb5-32447c5926d3"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("babebbe0-9ca4-4c5b-9b6f-d9ebe10922db"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("e5686099-ba60-4983-b940-ab848ed0f424"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("b22caebb-6792-4bcf-954e-2de1ad3eeb52"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("de132044-bcc3-4e81-b40f-5ed6a52c87b2"));

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "ClassGroupId", "DateOfBirth", "FirstName", "ImageUrl", "LastName", "MiddleName", "ParentId" },
                values: new object[] { new Guid("92435fe0-9992-4745-9295-c9c4c8b9258c"), 2, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "https://img.freepik.com/free-vector/cute-happy-smiling-child-isolated-white_1308-32243.jpg", "Iliev", "Hristov", new Guid("1af4589c-7297-4dbd-ad7d-bb275e8820b4") });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "KindergartenId", "Url" },
                values: new object[,]
                {
                    { new Guid("0ce90572-fbbb-4bc0-9516-91fedf182c16"), 1, "https://landezine.com/wp-content/uploads/2023/06/13-3-1270x846.jpg" },
                    { new Guid("7c57b8af-4db6-4663-bfd9-d807b57b6181"), 1, "https://file2.okorder.com/attach/2017/01/09/b6e37ea332d65dca1d4172df440fcc72.jpg" },
                    { new Guid("bafbf05b-63f1-46e4-809d-d8450be0d5aa"), 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTaUwQTx7J17GWtmvOuoaecCfBw7c-sUmOTk1xjm0IQQxjR2CZH0154QwUT103frsZBezI&usqp=CAU" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ClassGroupId", "EmailAddress", "ImageUrl", "Name", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { new Guid("1864eb71-02fc-4f2e-b83f-581c8a32feb7"), 2, "ivanova.22@teacher.com", "https://st.depositphotos.com/1758000/2947/v/450/depositphotos_29477577-stock-illustration-eyewear-glasses-teacher-touching-chin.jpg", "Silviq Ivanova", "+359789000000", "4b72b514-00e0-4754-ab43-4c53199afbb8" },
                    { new Guid("eb9d2f52-d98a-42d4-a709-8243ee9b7b37"), 1, "admin@admin.bg", "https://t4.ftcdn.net/jpg/04/75/00/99/360_F_475009987_zwsk4c77x3cTpcI3W1C1LU4pOSyPKaqi.jpg", "Admin Admin", "+359000000000", "1605dfd0-0033-408e-aae7-ca088e86985d" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("92435fe0-9992-4745-9295-c9c4c8b9258c"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("0ce90572-fbbb-4bc0-9516-91fedf182c16"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("7c57b8af-4db6-4663-bfd9-d807b57b6181"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("bafbf05b-63f1-46e4-809d-d8450be0d5aa"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("1864eb71-02fc-4f2e-b83f-581c8a32feb7"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("eb9d2f52-d98a-42d4-a709-8243ee9b7b37"));

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "ClassGroupId", "DateOfBirth", "FirstName", "ImageUrl", "IsAttending", "IsKindergartener", "LastName", "MiddleName", "ParentId" },
                values: new object[] { new Guid("828bc370-17a6-4b60-95e8-663fca82ce5b"), 2, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "https://img.freepik.com/free-vector/cute-happy-smiling-child-isolated-white_1308-32243.jpg", false, false, "Iliev", "Hristov", new Guid("1af4589c-7297-4dbd-ad7d-bb275e8820b4") });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "KindergartenId", "Url" },
                values: new object[,]
                {
                    { new Guid("51ed67bb-ace0-428c-bcb5-32447c5926d3"), 1, "https://landezine.com/wp-content/uploads/2023/06/13-3-1270x846.jpg" },
                    { new Guid("babebbe0-9ca4-4c5b-9b6f-d9ebe10922db"), 1, "https://file2.okorder.com/attach/2017/01/09/b6e37ea332d65dca1d4172df440fcc72.jpg" },
                    { new Guid("e5686099-ba60-4983-b940-ab848ed0f424"), 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTaUwQTx7J17GWtmvOuoaecCfBw7c-sUmOTk1xjm0IQQxjR2CZH0154QwUT103frsZBezI&usqp=CAU" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ClassGroupId", "EmailAddress", "ImageUrl", "Name", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { new Guid("b22caebb-6792-4bcf-954e-2de1ad3eeb52"), 2, "ivanova.22@teacher.com", "https://st.depositphotos.com/1758000/2947/v/450/depositphotos_29477577-stock-illustration-eyewear-glasses-teacher-touching-chin.jpg", "Silviq Ivanova", "+359789000000", "4b72b514-00e0-4754-ab43-4c53199afbb8" },
                    { new Guid("de132044-bcc3-4e81-b40f-5ed6a52c87b2"), 1, "admin@admin.bg", "https://t4.ftcdn.net/jpg/04/75/00/99/360_F_475009987_zwsk4c77x3cTpcI3W1C1LU4pOSyPKaqi.jpg", "Admin Admin", "+359000000000", "1605dfd0-0033-408e-aae7-ca088e86985d" }
                });
        }
    }
}
