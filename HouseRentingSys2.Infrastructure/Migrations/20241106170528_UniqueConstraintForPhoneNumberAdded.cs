using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSys2.Infrastructure.Migrations
{
    public partial class UniqueConstraintForPhoneNumberAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Agents",
                comment: "House Agent");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a6d25f6-9e37-455a-b89c-f284264a6b25", "AQAAAAEAACcQAAAAEGX/RF02E0nVW8L6XAbSB8HUJfosi9SbZ26vOysFYJSM/VSjfiz+mYOfNMnCnk822g==", "4ac84232-af4d-49af-b1d2-0903fa42447d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4cd90f5-671d-483c-96aa-2319586e5a19", "AQAAAAEAACcQAAAAEKCyJxk2DC5fdFrbfEDtTuF3G7B6/nB4kxwU6Md6OnSU+xad5xB5rRZSLSvfC2PP2A==", "33a31d7b-817d-4302-8cae-1a3b6e4c4aea" });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents");

            migrationBuilder.AlterTable(
                name: "Agents",
                oldComment: "House Agent");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3efa6721-1d45-473c-8568-fafaa34aaf64", "AQAAAAEAACcQAAAAEAa7dX/GMCIwo8cxF/6PTVR+aiR+1f0BUcEGL9w2jF4fZTProq5Ww9dwIBr2H4gnKw==", "4ce63a41-325b-43c2-8199-964bf8f8fc38" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0551fea8-36ec-4832-9036-eae8f221efcb", "AQAAAAEAACcQAAAAEP2hdSMTjSt80eSK1Z5ykH4X9BC5SRQ0zTkNDoYGsWZIAsmM8BuHyNANJpcAPvXg2Q==", "ef539845-c788-4e7f-8f63-10a294c0a7f2" });
        }
    }
}
