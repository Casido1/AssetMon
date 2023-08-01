using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetMon.Data.Migrations
{
    public partial class MakePaymentDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Vehicles_VehicleId",
                table: "Payment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0bd372e4-6b7a-46bb-83a5-ca01cd544bd2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fa76062-4b20-42ff-9d05-8207001e9675");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4968d656-904f-4b2e-98c8-d1ad07a02639");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleId",
                table: "Payment",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "200048fd-e2bd-4d6f-a03d-bef839c3790e", "38df81cf-4ae8-4fdd-afb3-48ba220721b3", "Driver", "DRIVER" },
                    { "80f06be8-2985-4ce8-95b6-48fef961fb79", "97e52c31-b73f-440a-9e3e-fb20eb3165c2", "Owner", "OWNER" },
                    { "9b8bb99e-c149-4e60-8f19-2e4f45303041", "72fee15d-bb99-40c9-b732-91e83478d757", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ee125f5-3be4-4bda-ae4c-d471762c414c",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "12b42ce9-2b61-4571-bd36-bf3b5e8289ea", "389936b1-0601-4f84-bc59-4b2edaa88537" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21443f16-6bfb-4b07-8f35-d4a876266d5b",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9b154eba-3961-43fc-ba34-15fcf8cb5f47", "67c2a2c5-0aae-4eea-b935-00bd87382d95" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "666e993e-bd32-4097-a572-702228c0df60",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4e8e6b88-0b0d-4b6f-bf53-d716dbf883b4", "75efa93e-8f43-4b29-8bbc-866781bba735" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c649c3c-a0f1-4065-832a-193cd3d9085d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fd7f954f-cc11-41f0-bc5d-9725bbc3f7ec", "78b7ca34-3a81-4549-aa0b-bd1f6f419b80" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d23d56ce-9953-4647-b594-340a50bf7320",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "50611ca0-d5c0-4939-8647-7d0961a820c3", "39e15a2a-b900-45e9-a926-bc74ab7470d7" });

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Vehicles_VehicleId",
                table: "Payment",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Vehicles_VehicleId",
                table: "Payment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "200048fd-e2bd-4d6f-a03d-bef839c3790e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80f06be8-2985-4ce8-95b6-48fef961fb79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b8bb99e-c149-4e60-8f19-2e4f45303041");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleId",
                table: "Payment",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0bd372e4-6b7a-46bb-83a5-ca01cd544bd2", "400fd777-f9c3-42d5-8bc5-aafbd88f3396", "Administrator", "ADMINISTRATOR" },
                    { "2fa76062-4b20-42ff-9d05-8207001e9675", "49af4034-555e-4b87-9808-e1f4511495bd", "Driver", "DRIVER" },
                    { "4968d656-904f-4b2e-98c8-d1ad07a02639", "9341f380-6f90-486e-9e74-fca2aaf53733", "Owner", "OWNER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ee125f5-3be4-4bda-ae4c-d471762c414c",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a377da85-9bc4-4f0e-8213-7724a961821b", "84db9a5f-6db3-4220-a440-a74a826bdad2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21443f16-6bfb-4b07-8f35-d4a876266d5b",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ecc64d03-5375-4947-8e6a-b6598bbbd5a9", "ce0cedb9-41ec-4f1e-8a07-b197dc4b29c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "666e993e-bd32-4097-a572-702228c0df60",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "105e82ae-c061-4c40-b82e-f0e80374d052", "b37bd117-0c0b-4511-b305-46133d0e6378" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c649c3c-a0f1-4065-832a-193cd3d9085d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "832ecd0f-54e3-43d9-871d-de0e9eb43c4f", "1f52793f-a452-44bf-8874-eb7b87aa1442" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d23d56ce-9953-4647-b594-340a50bf7320",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c7fe8421-2f57-4301-a6c4-3f8019cdab2b", "ed9b693f-e321-46ec-825f-72e6199b4ea3" });

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Vehicles_VehicleId",
                table: "Payment",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }
    }
}
