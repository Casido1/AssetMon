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
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b80fa78e-d0d3-45f7-8afa-5f8cc7cf8212", "f0c0499a-4f60-4a35-a307-869fea97a7dd", "Driver", "DRIVER" },
                    { "b98c6976-530d-43d1-8226-e97bc529f03c", "12584b16-83d8-4d7a-a2e6-5e7113657bc7", "Owner", "OWNER" },
                    { "f908f505-c3c4-43c0-a8d5-81f0a4b2e6c6", "ff717b50-4ae7-47c5-8fa1-68f04157ddd3", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1ee125f5-3be4-4bda-ae4c-d471762c414c", 0, "b4fc9651-09b6-4e33-84bd-e32c46e60bc9", "ahmedsani@gmail.com", false, "Ahmed", "Sani", false, null, null, null, null, null, false, null, "7f55ef55-3d60-4ace-8151-2eaae4c87fd7", false, null },
                    { "21443f16-6bfb-4b07-8f35-d4a876266d5b", 0, "2f62639d-4f6e-4b12-ac1b-04555b1bbd1d", "abubakarmohammed@gmail.com", false, "Abubakar", "Mohammed", false, null, null, null, null, null, false, null, "b83b2de7-0211-4ad6-9cbc-1f3ae058a586", false, null },
                    { "666e993e-bd32-4097-a572-702228c0df60", 0, "50726856-71a2-4577-bba2-c67b7de58470", "ugochukwu.anunihu@gmail.com", false, "Ugochukwu", "Anunihu", false, null, null, null, null, null, false, null, "1c2ab221-298b-4cfc-a9be-2443610fbaa0", false, null },
                    { "6c649c3c-a0f1-4065-832a-193cd3d9085d", 0, "29d34dc1-572e-47aa-a7a7-d66e6565664b", "idrissalisu@gmail.com", false, "Idris", "Salisu", false, null, null, null, null, null, false, null, "ad1c9959-7053-4b63-aecd-6a5d2ade5c66", false, null },
                    { "d23d56ce-9953-4647-b594-340a50bf7320", 0, "0d2916cb-547e-4649-80c1-a89530600989", "hamzaisah@gmail.com", false, "Hamza", "Isah", false, null, null, null, null, null, false, null, "bbff87e4-cd6b-46bb-864f-9c2ea6b63a42", false, null }
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
                unique: true);

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
