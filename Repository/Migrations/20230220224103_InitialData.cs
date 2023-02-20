using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetMon.Data.Migrations
{
    public partial class InitialData : Migration
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
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_AspNetUsers_Id",
                        column: x => x.Id,
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
                name: "Asset",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DriverId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractType = table.Column<int>(type: "int", nullable: true),
                    Tenure = table.Column<int>(type: "int", nullable: true),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentFrequency = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asset_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Asset_AspNetUsers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Asset_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AssetId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RepairName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repairs_Asset_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Asset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "55af4fe3-c19f-448f-804f-2576f14afd25", "a157b323-c940-437e-965a-dfe7d453640f", "Administrator", "ADMINISTRATOR" },
                    { "70fd24c6-124b-4a42-a294-fc75f9dd7ccd", "78ac7d62-b69c-4b9e-9f44-5c0cd732ad39", "Driver", "DRIVER" },
                    { "a640d483-e7fa-44bc-aed5-adae34139451", "32ef78ac-31d1-42ac-84a0-be052fff4bb5", "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1ee125f5-3be4-4bda-ae4c-d471762c414c", 0, "8b80b6a1-b72c-4de6-9cf6-01b57a03f235", "ahmedsani@gmail.com", false, "Ahmed", "Sani", false, null, null, null, null, null, false, null, "b7b71cf0-0628-46e6-aca9-ca42b3eb5482", false, null },
                    { "21443f16-6bfb-4b07-8f35-d4a876266d5b", 0, "20a590f3-a4ed-41ed-a083-931e58edc4dc", "abubakarmohammed@gmail.com", false, "Abubakar", "Mohammed", false, null, null, null, null, null, false, null, "1ef4c0c6-c3b1-46fb-a6b3-e7f6dbb90e2e", false, null },
                    { "666e993e-bd32-4097-a572-702228c0df60", 0, "e0049761-0ff4-4a65-a25f-7bc983b71802", "ugochukwu.anunihu@gmail.com", false, "Ugochukwu", "Anunihu", false, null, null, null, null, null, false, null, "9e344682-6057-4210-a892-dc12041688b4", false, null },
                    { "6c649c3c-a0f1-4065-832a-193cd3d9085d", 0, "64465da4-1b8d-4201-9ccc-b871b7d15cbb", "idrissalisu@gmail.com", false, "Idris", "Salisu", false, null, null, null, null, null, false, null, "fe06fe85-6fb4-4bdc-af8e-4453b66b4fc5", false, null },
                    { "d23d56ce-9953-4647-b594-340a50bf7320", 0, "9b975a7d-c251-46f4-8a55-6c39cabedb6c", "hamzaisah@gmail.com", false, "Hamza", "Isah", false, null, null, null, null, null, false, null, "f7d52b2e-ee00-4298-8cdf-8c0cd784a953", false, null }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "State", "Street" },
                values: new object[,]
                {
                    { "1ee125f5-3be4-4bda-ae4c-d471762c414c", "PortHarcourt", "Nigeria", "Rivers", "3 Twin Tower, Igbogo Road, Choba" },
                    { "21443f16-6bfb-4b07-8f35-d4a876266d5b", "PortHarcourt", "Nigeria", "Rivers", "5 Twin Tower, Igbogo Road, Choba" },
                    { "666e993e-bd32-4097-a572-702228c0df60", "PortHarcourt", "Nigeria", "Rivers", "4 radio Estate, Ozuoba" },
                    { "6c649c3c-a0f1-4065-832a-193cd3d9085d", "PortHarcourt", "Nigeria", "Rivers", "4 Twin Tower, Igbogo Road, Choba" },
                    { "d23d56ce-9953-4647-b594-340a50bf7320", "PortHarcourt", "Nigeria", "Rivers", "6 Twin Tower, Igbogo Road, Choba" }
                });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "Id", "AppUserId", "Color", "ContractType", "Discriminator", "DriverId", "IsActive", "Name", "OwnerId", "PaymentAmount", "PaymentFrequency", "PlateNumber", "StartDate", "Tenure", "Type" },
                values: new object[,]
                {
                    { "1c4690e6-3e15-40f6-a6a2-7bdfe48817a2", null, "Blue", 1, "Vehicle", "1ee125f5-3be4-4bda-ae4c-d471762c414c", false, "Piaggio", "666e993e-bd32-4097-a572-702228c0df60", 16000m, 1, null, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "3e187f49-53b8-4049-b12d-3c80ab7a9048", null, "Blue", 1, "Vehicle", "21443f16-6bfb-4b07-8f35-d4a876266d5b", false, "TVS", "666e993e-bd32-4097-a572-702228c0df60", 16000m, 1, "TVS-M4L03958", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "96d62347-64d8-425b-8a66-4b8cd78fc5a3", null, "Blue", 1, "Vehicle", "6c649c3c-a0f1-4065-832a-193cd3d9085d", false, "TVS", "666e993e-bd32-4097-a572-702228c0df60", 16000m, 1, "TVS-UMG-210-QR", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "e6ab22dc-f77a-4b94-8bef-ff8d2c9d16cb", null, "Blue", 1, "Vehicle", "d23d56ce-9953-4647-b594-340a50bf7320", false, "TVS", "666e993e-bd32-4097-a572-702228c0df60", 16000m, 1, "TVS-M4L03941", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null }
                });

            migrationBuilder.InsertData(
                table: "Repairs",
                columns: new[] { "Id", "Amount", "AssetId", "RepairName" },
                values: new object[] { "8c5ccdaa-eda0-4d29-94cc-aac10a0883f1", 3000m, "1c4690e6-3e15-40f6-a6a2-7bdfe48817a2", "Shoe brakes" });

            migrationBuilder.InsertData(
                table: "Repairs",
                columns: new[] { "Id", "Amount", "AssetId", "RepairName" },
                values: new object[] { "f6040dcd-c639-4b07-94ce-0c7ef58d7250", 3000m, "3e187f49-53b8-4049-b12d-3c80ab7a9048", "Shoe brakes" });

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
                name: "IX_Asset_AppUserId",
                table: "Asset",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_DriverId",
                table: "Asset",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_OwnerId",
                table: "Asset",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_AssetId",
                table: "Repairs",
                column: "AssetId");
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
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
