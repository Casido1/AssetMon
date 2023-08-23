using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetMon.Data.Migrations
{
    public partial class AddUserProfileEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_AppUserId",
                table: "Addresses");

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: "1ee125f5-3be4-4bda-ae4c-d471762c414c");

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: "21443f16-6bfb-4b07-8f35-d4a876266d5b");

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: "666e993e-bd32-4097-a572-702228c0df60");

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: "6c649c3c-a0f1-4065-832a-193cd3d9085d");

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: "d23d56ce-9953-4647-b594-340a50bf7320");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "463548b4-126a-48c8-b773-18bbc24c4821");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d76f462-34a7-4b92-bb7c-40f04e4f76d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4b589b1-a83d-4902-97a7-a57b18f46919");

            migrationBuilder.DeleteData(
                table: "Ownerships",
                keyColumns: new[] { "AppUserId", "VehicleId" },
                keyValues: new object[] { "1ee125f5-3be4-4bda-ae4c-d471762c414c", "96d62347-64d8-425b-8a66-4b8cd78fc5a3" });

            migrationBuilder.DeleteData(
                table: "Ownerships",
                keyColumns: new[] { "AppUserId", "VehicleId" },
                keyValues: new object[] { "21443f16-6bfb-4b07-8f35-d4a876266d5b", "3e187f49-53b8-4049-b12d-3c80ab7a9048" });

            migrationBuilder.DeleteData(
                table: "Ownerships",
                keyColumns: new[] { "AppUserId", "VehicleId" },
                keyValues: new object[] { "666e993e-bd32-4097-a572-702228c0df60", "1c4690e6-3e15-40f6-a6a2-7bdfe48817a2" });

            migrationBuilder.DeleteData(
                table: "Ownerships",
                keyColumns: new[] { "AppUserId", "VehicleId" },
                keyValues: new object[] { "666e993e-bd32-4097-a572-702228c0df60", "3e187f49-53b8-4049-b12d-3c80ab7a9048" });

            migrationBuilder.DeleteData(
                table: "Ownerships",
                keyColumns: new[] { "AppUserId", "VehicleId" },
                keyValues: new object[] { "666e993e-bd32-4097-a572-702228c0df60", "96d62347-64d8-425b-8a66-4b8cd78fc5a3" });

            migrationBuilder.DeleteData(
                table: "Ownerships",
                keyColumns: new[] { "AppUserId", "VehicleId" },
                keyValues: new object[] { "666e993e-bd32-4097-a572-702228c0df60", "e6ab22dc-f77a-4b94-8bef-ff8d2c9d16cb" });

            migrationBuilder.DeleteData(
                table: "Ownerships",
                keyColumns: new[] { "AppUserId", "VehicleId" },
                keyValues: new object[] { "6c649c3c-a0f1-4065-832a-193cd3d9085d", "1c4690e6-3e15-40f6-a6a2-7bdfe48817a2" });

            migrationBuilder.DeleteData(
                table: "Ownerships",
                keyColumns: new[] { "AppUserId", "VehicleId" },
                keyValues: new object[] { "d23d56ce-9953-4647-b594-340a50bf7320", "e6ab22dc-f77a-4b94-8bef-ff8d2c9d16cb" });

            migrationBuilder.DeleteData(
                table: "VehicleRepairs",
                keyColumn: "Id",
                keyValue: "8c5ccdaa-eda0-4d29-94cc-aac10a0883f1");

            migrationBuilder.DeleteData(
                table: "VehicleRepairs",
                keyColumn: "Id",
                keyValue: "f6040dcd-c639-4b07-94ce-0c7ef58d7250");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ee125f5-3be4-4bda-ae4c-d471762c414c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21443f16-6bfb-4b07-8f35-d4a876266d5b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "666e993e-bd32-4097-a572-702228c0df60");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c649c3c-a0f1-4065-832a-193cd3d9085d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d23d56ce-9953-4647-b594-340a50bf7320");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: "1c4690e6-3e15-40f6-a6a2-7bdfe48817a2");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: "3e187f49-53b8-4049-b12d-3c80ab7a9048");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: "96d62347-64d8-425b-8a66-4b8cd78fc5a3");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: "e6ab22dc-f77a-4b94-8bef-ff8d2c9d16cb");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Addresses",
                newName: "UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_AppUserId",
                table: "Addresses",
                newName: "IX_Addresses_UserProfileId");

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_AppUserId",
                table: "UserProfiles",
                column: "AppUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_UserProfiles_UserProfileId",
                table: "Addresses",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_UserProfiles_UserProfileId",
                table: "Addresses");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "Addresses",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_UserProfileId",
                table: "Addresses",
                newName: "IX_Addresses_AppUserId");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "463548b4-126a-48c8-b773-18bbc24c4821", "85705c27-3914-4716-b1fa-29033308142e", "Driver", "DRIVER" },
                    { "6d76f462-34a7-4b92-bb7c-40f04e4f76d0", "d75cfd53-bdec-4f9a-a334-cbbfd8962791", "Owner", "OWNER" },
                    { "d4b589b1-a83d-4902-97a7-a57b18f46919", "9689a6b9-87b3-42d1-8ab2-df000a51bb26", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoUrl", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1ee125f5-3be4-4bda-ae4c-d471762c414c", 0, "0a7f3abf-1982-44e7-9913-67c58340fcc2", "ahmedsani@gmail.com", false, "Ahmed", "Sani", false, null, null, null, null, null, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "e7766ba1-86f0-437a-87a3-a395011b8615", false, null },
                    { "21443f16-6bfb-4b07-8f35-d4a876266d5b", 0, "e7ba4cfa-9b17-406c-af06-2439909983a6", "abubakarmohammed@gmail.com", false, "Abubakar", "Mohammed", false, null, null, null, null, null, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2a2583ef-9661-4c5e-b264-b5688243c7e7", false, null },
                    { "666e993e-bd32-4097-a572-702228c0df60", 0, "5336485a-22aa-42bc-9597-5ee8fe0e6db4", "ugochukwu.anunihu@gmail.com", false, "Ugochukwu", "Anunihu", false, null, null, null, null, null, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7eae94e9-8297-42a3-8b42-b809a0dd60c1", false, null },
                    { "6c649c3c-a0f1-4065-832a-193cd3d9085d", 0, "046f7763-6d4c-4e31-95ed-1af7d3acd036", "idrissalisu@gmail.com", false, "Idris", "Salisu", false, null, null, null, null, null, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cfc83d76-c833-4758-aabc-0f4fadac9821", false, null },
                    { "d23d56ce-9953-4647-b594-340a50bf7320", 0, "3cb42618-78b1-48cf-a1aa-8a5009899612", "hamzaisah@gmail.com", false, "Hamza", "Isah", false, null, null, null, null, null, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1400a9d1-5dba-4c13-825e-0c5f49d4a275", false, null }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Color", "ContractType", "IsActive", "Name", "PaymentAmount", "PaymentFrequency", "PlateNumber", "StartDate", "Tenure" },
                values: new object[,]
                {
                    { "1c4690e6-3e15-40f6-a6a2-7bdfe48817a2", "Blue", 2, false, "Piaggio", 16000m, 2, null, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "3e187f49-53b8-4049-b12d-3c80ab7a9048", "Blue", 2, false, "TVS", 16000m, 2, "TVS-M4L03958", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "96d62347-64d8-425b-8a66-4b8cd78fc5a3", "Blue", 2, false, "TVS", 16000m, 2, "TVS-UMG-210-QR", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "e6ab22dc-f77a-4b94-8bef-ff8d2c9d16cb", "Blue", 2, false, "TVS", 16000m, 2, "TVS-M4L03941", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AppUserId", "City", "Country", "State", "Street" },
                values: new object[,]
                {
                    { "1ee125f5-3be4-4bda-ae4c-d471762c414c", "1ee125f5-3be4-4bda-ae4c-d471762c414c", "PortHarcourt", "Nigeria", "Rivers", "3 Twin Tower, Igbogo Road, Choba" },
                    { "21443f16-6bfb-4b07-8f35-d4a876266d5b", "21443f16-6bfb-4b07-8f35-d4a876266d5b", "PortHarcourt", "Nigeria", "Rivers", "5 Twin Tower, Igbogo Road, Choba" },
                    { "666e993e-bd32-4097-a572-702228c0df60", "666e993e-bd32-4097-a572-702228c0df60", "PortHarcourt", "Nigeria", "Rivers", "4 radio Estate, Ozuoba" },
                    { "6c649c3c-a0f1-4065-832a-193cd3d9085d", "6c649c3c-a0f1-4065-832a-193cd3d9085d", "PortHarcourt", "Nigeria", "Rivers", "4 Twin Tower, Igbogo Road, Choba" },
                    { "d23d56ce-9953-4647-b594-340a50bf7320", "d23d56ce-9953-4647-b594-340a50bf7320", "PortHarcourt", "Nigeria", "Rivers", "6 Twin Tower, Igbogo Road, Choba" }
                });

            migrationBuilder.InsertData(
                table: "Ownerships",
                columns: new[] { "AppUserId", "VehicleId" },
                values: new object[,]
                {
                    { "1ee125f5-3be4-4bda-ae4c-d471762c414c", "96d62347-64d8-425b-8a66-4b8cd78fc5a3" },
                    { "21443f16-6bfb-4b07-8f35-d4a876266d5b", "3e187f49-53b8-4049-b12d-3c80ab7a9048" },
                    { "666e993e-bd32-4097-a572-702228c0df60", "1c4690e6-3e15-40f6-a6a2-7bdfe48817a2" },
                    { "666e993e-bd32-4097-a572-702228c0df60", "3e187f49-53b8-4049-b12d-3c80ab7a9048" },
                    { "666e993e-bd32-4097-a572-702228c0df60", "96d62347-64d8-425b-8a66-4b8cd78fc5a3" },
                    { "666e993e-bd32-4097-a572-702228c0df60", "e6ab22dc-f77a-4b94-8bef-ff8d2c9d16cb" },
                    { "6c649c3c-a0f1-4065-832a-193cd3d9085d", "1c4690e6-3e15-40f6-a6a2-7bdfe48817a2" },
                    { "d23d56ce-9953-4647-b594-340a50bf7320", "e6ab22dc-f77a-4b94-8bef-ff8d2c9d16cb" }
                });

            migrationBuilder.InsertData(
                table: "VehicleRepairs",
                columns: new[] { "Id", "Amount", "Date", "RepairName", "VehicleId" },
                values: new object[,]
                {
                    { "8c5ccdaa-eda0-4d29-94cc-aac10a0883f1", 3000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shoe brakes", "1c4690e6-3e15-40f6-a6a2-7bdfe48817a2" },
                    { "f6040dcd-c639-4b07-94ce-0c7ef58d7250", 3000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shoe brakes", "3e187f49-53b8-4049-b12d-3c80ab7a9048" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_AppUserId",
                table: "Addresses",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
