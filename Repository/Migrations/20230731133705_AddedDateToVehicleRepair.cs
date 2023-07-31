using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetMon.Data.Migrations
{
    public partial class AddedDateToVehicleRepair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b80fa78e-d0d3-45f7-8afa-5f8cc7cf8212");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b98c6976-530d-43d1-8226-e97bc529f03c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f908f505-c3c4-43c0-a8d5-81f0a4b2e6c6");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "VehicleRepairs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Date",
                table: "VehicleRepairs");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b80fa78e-d0d3-45f7-8afa-5f8cc7cf8212", "f0c0499a-4f60-4a35-a307-869fea97a7dd", "Driver", "DRIVER" },
                    { "b98c6976-530d-43d1-8226-e97bc529f03c", "12584b16-83d8-4d7a-a2e6-5e7113657bc7", "Owner", "OWNER" },
                    { "f908f505-c3c4-43c0-a8d5-81f0a4b2e6c6", "ff717b50-4ae7-47c5-8fa1-68f04157ddd3", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ee125f5-3be4-4bda-ae4c-d471762c414c",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b4fc9651-09b6-4e33-84bd-e32c46e60bc9", "7f55ef55-3d60-4ace-8151-2eaae4c87fd7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21443f16-6bfb-4b07-8f35-d4a876266d5b",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2f62639d-4f6e-4b12-ac1b-04555b1bbd1d", "b83b2de7-0211-4ad6-9cbc-1f3ae058a586" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "666e993e-bd32-4097-a572-702228c0df60",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "50726856-71a2-4577-bba2-c67b7de58470", "1c2ab221-298b-4cfc-a9be-2443610fbaa0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c649c3c-a0f1-4065-832a-193cd3d9085d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "29d34dc1-572e-47aa-a7a7-d66e6565664b", "ad1c9959-7053-4b63-aecd-6a5d2ade5c66" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d23d56ce-9953-4647-b594-340a50bf7320",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0d2916cb-547e-4649-80c1-a89530600989", "bbff87e4-cd6b-46bb-864f-9c2ea6b63a42" });
        }
    }
}
