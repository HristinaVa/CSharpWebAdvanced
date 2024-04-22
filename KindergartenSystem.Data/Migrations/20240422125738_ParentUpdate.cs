using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KindergartenSystem.Data.Migrations
{
    public partial class ParentUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "PhoneNumberSecond",
                table: "Parents");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Parents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "ClassGroupId", "DateOfBirth", "FirstName", "ImageUrl", "LastName", "MiddleName", "ParentId" },
                values: new object[] { new Guid("9b830029-82e4-4505-8d19-e8556512958d"), 2, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "https://img.freepik.com/free-vector/cute-happy-smiling-child-isolated-white_1308-32243.jpg", "Iliev", "Hristov", new Guid("1af4589c-7297-4dbd-ad7d-bb275e8820b4") });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "KindergartenId", "Url" },
                values: new object[,]
                {
                    { new Guid("89142d1e-19be-4064-a04d-f95543c86be7"), 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTaUwQTx7J17GWtmvOuoaecCfBw7c-sUmOTk1xjm0IQQxjR2CZH0154QwUT103frsZBezI&usqp=CAU" },
                    { new Guid("ba3ec51a-2d07-4fcc-b06c-f62c0c7452e8"), 1, "https://landezine.com/wp-content/uploads/2023/06/13-3-1270x846.jpg" },
                    { new Guid("df6ae1fa-7c9b-482d-bf22-1c376ba067c2"), 1, "https://file2.okorder.com/attach/2017/01/09/b6e37ea332d65dca1d4172df440fcc72.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ClassGroupId", "EmailAddress", "ImageUrl", "Name", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { new Guid("1dd503a1-0038-4ac2-bcd0-38c85966d742"), 2, "ivanova.22@teacher.com", "https://st.depositphotos.com/1758000/2947/v/450/depositphotos_29477577-stock-illustration-eyewear-glasses-teacher-touching-chin.jpg", "Silviq Ivanova", "+359789000000", "4b72b514-00e0-4754-ab43-4c53199afbb8" },
                    { new Guid("afba2f05-33df-4738-a6aa-a4af80cb5531"), 1, "admin@admin.bg", "https://t4.ftcdn.net/jpg/04/75/00/99/360_F_475009987_zwsk4c77x3cTpcI3W1C1LU4pOSyPKaqi.jpg", "Admin Admin", "+359000000000", "1605dfd0-0033-408e-aae7-ca088e86985d" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("9b830029-82e4-4505-8d19-e8556512958d"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("89142d1e-19be-4064-a04d-f95543c86be7"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("ba3ec51a-2d07-4fcc-b06c-f62c0c7452e8"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("df6ae1fa-7c9b-482d-bf22-1c376ba067c2"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("1dd503a1-0038-4ac2-bcd0-38c85966d742"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("afba2f05-33df-4738-a6aa-a4af80cb5531"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Parents");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumberSecond",
                table: "Parents",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "ClassGroupId", "DateOfBirth", "FirstName", "ImageUrl", "IsAttending", "IsKindergartener", "LastName", "MiddleName", "ParentId" },
                values: new object[] { new Guid("92435fe0-9992-4745-9295-c9c4c8b9258c"), 2, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "https://img.freepik.com/free-vector/cute-happy-smiling-child-isolated-white_1308-32243.jpg", false, false, "Iliev", "Hristov", new Guid("1af4589c-7297-4dbd-ad7d-bb275e8820b4") });

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
    }
}
