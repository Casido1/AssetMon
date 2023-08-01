using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetMon.Data.Migrations
{
    public partial class PaymentEntityMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Vehicles_VehicleId",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
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

            migrationBuilder.RenameTable(
                name: "Payment",
                newName: "Payments");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_VehicleId",
                table: "Payments",
                newName: "IX_Payments_VehicleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "164d1341-6ee5-4d65-9763-1b2c91428c99", "9784f537-3455-456d-a647-165fe06a0c6a", "Administrator", "ADMINISTRATOR" },
                    { "1ed26f58-ddff-4a71-b517-6aafdba26795", "27caef73-fef9-4ee0-8dc1-ada5372c0ada", "Owner", "OWNER" },
                    { "6eb2518b-422c-4e85-ae68-123ab1127564", "022e4e1c-5d5c-4cd1-9674-bf467b4e46b6", "Driver", "DRIVER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ee125f5-3be4-4bda-ae4c-d471762c414c",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "25cb0ffb-a8a2-4355-b7a9-b83de0ce9a36", "d1bdddbc-d7a9-4547-968c-622d23bc6143" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21443f16-6bfb-4b07-8f35-d4a876266d5b",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "61927f05-c132-4e48-a93b-89cc822ca38b", "90c3f8b6-796a-4898-9176-b62cf3766f9f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "666e993e-bd32-4097-a572-702228c0df60",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "891d091e-cf9a-4b8d-b1c5-d0b9eeddecdf", "295bf775-19ff-4a2e-8b9f-936dc16b8a57" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c649c3c-a0f1-4065-832a-193cd3d9085d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "59022eb0-8d26-4de0-b031-553bf0e32093", "68a376a3-e721-4d29-8151-bc67e5def723" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d23d56ce-9953-4647-b594-340a50bf7320",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "233b9e6c-5697-47b6-b8fd-356e4c3f557f", "c209caf4-321d-464b-b84f-ea319302c977" });

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Vehicles_VehicleId",
                table: "Payments",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Vehicles_VehicleId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "164d1341-6ee5-4d65-9763-1b2c91428c99");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ed26f58-ddff-4a71-b517-6aafdba26795");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6eb2518b-422c-4e85-ae68-123ab1127564");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "Payment");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_VehicleId",
                table: "Payment",
                newName: "IX_Payment_VehicleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "Id");

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
    }
}
