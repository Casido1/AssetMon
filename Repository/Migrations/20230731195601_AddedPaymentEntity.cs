using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetMon.Data.Migrations
{
    public partial class AddedPaymentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9af902dd-a22d-4ba0-b552-00954b6d8635");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab6bd0f6-6189-476f-820f-f509200f1d56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b43f9343-fa45-4935-b7d1-426046a9ba93");

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VehicleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Payment_VehicleId",
                table: "Payment",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9af902dd-a22d-4ba0-b552-00954b6d8635", "fc4f8757-3905-4fc5-9e48-798dd4287f89", "Administrator", "ADMINISTRATOR" },
                    { "ab6bd0f6-6189-476f-820f-f509200f1d56", "299344bc-5090-4c47-82aa-dbbd0d591f51", "Owner", "OWNER" },
                    { "b43f9343-fa45-4935-b7d1-426046a9ba93", "90c739fa-e858-4213-a113-f50d64ce822f", "Driver", "DRIVER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ee125f5-3be4-4bda-ae4c-d471762c414c",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b1076f77-8c5e-412f-bc0a-20e3af3d0a1f", "825c34c6-6f30-436c-bba5-705baf0d07b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21443f16-6bfb-4b07-8f35-d4a876266d5b",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8789736e-c8f8-4c68-bf4c-e07083a7cf95", "b5695812-7346-486a-8eed-18af0e139d59" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "666e993e-bd32-4097-a572-702228c0df60",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "eadec2a5-1af2-447d-8bfe-fc3772d19d77", "90263ca4-336a-44c9-ae70-0f67d3234f47" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c649c3c-a0f1-4065-832a-193cd3d9085d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "17104b8c-4c4a-439e-9867-517cf6817355", "d4b17663-216f-47d3-a520-f297a931e0d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d23d56ce-9953-4647-b594-340a50bf7320",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "450356c0-7873-4330-ac98-833fcdc0045e", "60eb8a0f-e09b-4634-8301-7c002e4e2a9f" });
        }
    }
}
