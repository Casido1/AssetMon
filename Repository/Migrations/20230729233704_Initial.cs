using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetMon.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractType = table.Column<int>(type: "int", nullable: false),
                    Tenure = table.Column<int>(type: "int", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentFrequency = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ownerships",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VehicleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ownerships", x => new { x.AppUserId, x.VehicleId });
                    table.ForeignKey(
                        name: "FK_Ownerships_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ownerships_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleRepairs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VehicleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RepairName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleRepairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleRepairs_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AppUserId", "City", "Country", "State", "Street" },
                values: new object[,]
                {
                    { "1ee125f5-3be4-4bda-ae4c-d471762c414c", null, "PortHarcourt", "Nigeria", "Rivers", "3 Twin Tower, Igbogo Road, Choba" },
                    { "21443f16-6bfb-4b07-8f35-d4a876266d5b", null, "PortHarcourt", "Nigeria", "Rivers", "5 Twin Tower, Igbogo Road, Choba" },
                    { "666e993e-bd32-4097-a572-702228c0df60", null, "PortHarcourt", "Nigeria", "Rivers", "4 radio Estate, Ozuoba" },
                    { "6c649c3c-a0f1-4065-832a-193cd3d9085d", null, "PortHarcourt", "Nigeria", "Rivers", "4 Twin Tower, Igbogo Road, Choba" },
                    { "d23d56ce-9953-4647-b594-340a50bf7320", null, "PortHarcourt", "Nigeria", "Rivers", "6 Twin Tower, Igbogo Road, Choba" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06efdcdd-083f-4645-bdcd-1d17c5581eb1", "4ac06f7b-1020-4d18-b2af-3b8a77cfe8db", "Owner", "OWNER" },
                    { "d1b54257-10ed-4698-bd20-92532b25e49e", "fe9a7e97-2999-48ef-99c8-b7f2167ef964", "Administrator", "ADMINISTRATOR" },
                    { "fb3984bb-4fc2-4a10-ae0b-5b84d6575e6f", "5acde9f5-3a21-47ae-8f09-94177278a5dd", "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1ee125f5-3be4-4bda-ae4c-d471762c414c", 0, "ad2d09f6-8a01-43c1-a697-6fd7ea1cccb2", "ahmedsani@gmail.com", false, "Ahmed", "Sani", false, null, null, null, null, null, false, null, "0e935b89-cbb6-42d1-be22-e6ed4e16d296", false, null },
                    { "21443f16-6bfb-4b07-8f35-d4a876266d5b", 0, "be05f6a3-7088-47b7-ab00-51ce379d505a", "abubakarmohammed@gmail.com", false, "Abubakar", "Mohammed", false, null, null, null, null, null, false, null, "732ff1be-83cc-4991-89bc-9be321db8823", false, null },
                    { "666e993e-bd32-4097-a572-702228c0df60", 0, "492317c7-52be-4a63-8d93-c91c93723127", "ugochukwu.anunihu@gmail.com", false, "Ugochukwu", "Anunihu", false, null, null, null, null, null, false, null, "9782b267-bc02-45e6-9934-033b94c807c8", false, null },
                    { "6c649c3c-a0f1-4065-832a-193cd3d9085d", 0, "3b13bd53-0a02-4c18-b8aa-a5b54c4633ad", "idrissalisu@gmail.com", false, "Idris", "Salisu", false, null, null, null, null, null, false, null, "5c97d27d-4032-43df-81b4-f0d6d37f754b", false, null },
                    { "d23d56ce-9953-4647-b594-340a50bf7320", 0, "bc33a437-8662-40a3-8d83-abb46f85f190", "hamzaisah@gmail.com", false, "Hamza", "Isah", false, null, null, null, null, null, false, null, "4b844b8a-ef50-43fd-98ce-ff72f133fe84", false, null }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Color", "ContractType", "IsActive", "Name", "PaymentAmount", "PaymentFrequency", "PlateNumber", "StartDate", "Tenure" },
                values: new object[,]
                {
                    { "1c4690e6-3e15-40f6-a6a2-7bdfe48817a2", "Blue", 1, false, "Piaggio", 16000m, 1, null, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "3e187f49-53b8-4049-b12d-3c80ab7a9048", "Blue", 1, false, "TVS", 16000m, 1, "TVS-M4L03958", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "96d62347-64d8-425b-8a66-4b8cd78fc5a3", "Blue", 1, false, "TVS", 16000m, 1, "TVS-UMG-210-QR", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "e6ab22dc-f77a-4b94-8bef-ff8d2c9d16cb", "Blue", 1, false, "TVS", 16000m, 1, "TVS-M4L03941", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
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
                columns: new[] { "Id", "Amount", "RepairName", "VehicleId" },
                values: new object[,]
                {
                    { "8c5ccdaa-eda0-4d29-94cc-aac10a0883f1", 3000m, "Shoe brakes", "1c4690e6-3e15-40f6-a6a2-7bdfe48817a2" },
                    { "f6040dcd-c639-4b07-94ce-0c7ef58d7250", 3000m, "Shoe brakes", "3e187f49-53b8-4049-b12d-3c80ab7a9048" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AppUserId",
                table: "Addresses",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ownerships_VehicleId",
                table: "Ownerships",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleRepairs_VehicleId",
                table: "VehicleRepairs",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Ownerships");

            migrationBuilder.DropTable(
                name: "VehicleRepairs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
