﻿// <auto-generated />
using System;
using AssetMon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AssetMon.Data.Migrations
{
    [DbContext(typeof(AssetMonContext))]
    [Migration("20230801064748_MakePaymentDeleteCascade")]
    partial class MakePaymentDeleteCascade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AssetMon.Models.Address", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = "1ee125f5-3be4-4bda-ae4c-d471762c414c",
                            AppUserId = "1ee125f5-3be4-4bda-ae4c-d471762c414c",
                            City = "PortHarcourt",
                            Country = "Nigeria",
                            State = "Rivers",
                            Street = "3 Twin Tower, Igbogo Road, Choba"
                        },
                        new
                        {
                            Id = "6c649c3c-a0f1-4065-832a-193cd3d9085d",
                            AppUserId = "6c649c3c-a0f1-4065-832a-193cd3d9085d",
                            City = "PortHarcourt",
                            Country = "Nigeria",
                            State = "Rivers",
                            Street = "4 Twin Tower, Igbogo Road, Choba"
                        },
                        new
                        {
                            Id = "21443f16-6bfb-4b07-8f35-d4a876266d5b",
                            AppUserId = "21443f16-6bfb-4b07-8f35-d4a876266d5b",
                            City = "PortHarcourt",
                            Country = "Nigeria",
                            State = "Rivers",
                            Street = "5 Twin Tower, Igbogo Road, Choba"
                        },
                        new
                        {
                            Id = "d23d56ce-9953-4647-b594-340a50bf7320",
                            AppUserId = "d23d56ce-9953-4647-b594-340a50bf7320",
                            City = "PortHarcourt",
                            Country = "Nigeria",
                            State = "Rivers",
                            Street = "6 Twin Tower, Igbogo Road, Choba"
                        },
                        new
                        {
                            Id = "666e993e-bd32-4097-a572-702228c0df60",
                            AppUserId = "666e993e-bd32-4097-a572-702228c0df60",
                            City = "PortHarcourt",
                            Country = "Nigeria",
                            State = "Rivers",
                            Street = "4 radio Estate, Ozuoba"
                        });
                });

            modelBuilder.Entity("AssetMon.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1ee125f5-3be4-4bda-ae4c-d471762c414c",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "12b42ce9-2b61-4571-bd36-bf3b5e8289ea",
                            Email = "ahmedsani@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Ahmed",
                            LastName = "Sani",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "389936b1-0601-4f84-bc59-4b2edaa88537",
                            TwoFactorEnabled = false
                        },
                        new
                        {
                            Id = "6c649c3c-a0f1-4065-832a-193cd3d9085d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "fd7f954f-cc11-41f0-bc5d-9725bbc3f7ec",
                            Email = "idrissalisu@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Idris",
                            LastName = "Salisu",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "78b7ca34-3a81-4549-aa0b-bd1f6f419b80",
                            TwoFactorEnabled = false
                        },
                        new
                        {
                            Id = "21443f16-6bfb-4b07-8f35-d4a876266d5b",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9b154eba-3961-43fc-ba34-15fcf8cb5f47",
                            Email = "abubakarmohammed@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Abubakar",
                            LastName = "Mohammed",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "67c2a2c5-0aae-4eea-b935-00bd87382d95",
                            TwoFactorEnabled = false
                        },
                        new
                        {
                            Id = "d23d56ce-9953-4647-b594-340a50bf7320",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "50611ca0-d5c0-4939-8647-7d0961a820c3",
                            Email = "hamzaisah@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Hamza",
                            LastName = "Isah",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "39e15a2a-b900-45e9-a926-bc74ab7470d7",
                            TwoFactorEnabled = false
                        },
                        new
                        {
                            Id = "666e993e-bd32-4097-a572-702228c0df60",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4e8e6b88-0b0d-4b6f-bf53-d716dbf883b4",
                            Email = "ugochukwu.anunihu@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Ugochukwu",
                            LastName = "Anunihu",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "75efa93e-8f43-4b29-8bbc-866781bba735",
                            TwoFactorEnabled = false
                        });
                });

            modelBuilder.Entity("AssetMon.Models.Ownership", b =>
                {
                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VehicleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AppUserId", "VehicleId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Ownerships");

                    b.HasData(
                        new
                        {
                            AppUserId = "666e993e-bd32-4097-a572-702228c0df60",
                            VehicleId = "96d62347-64d8-425b-8a66-4b8cd78fc5a3"
                        },
                        new
                        {
                            AppUserId = "666e993e-bd32-4097-a572-702228c0df60",
                            VehicleId = "1c4690e6-3e15-40f6-a6a2-7bdfe48817a2"
                        },
                        new
                        {
                            AppUserId = "666e993e-bd32-4097-a572-702228c0df60",
                            VehicleId = "3e187f49-53b8-4049-b12d-3c80ab7a9048"
                        },
                        new
                        {
                            AppUserId = "666e993e-bd32-4097-a572-702228c0df60",
                            VehicleId = "e6ab22dc-f77a-4b94-8bef-ff8d2c9d16cb"
                        },
                        new
                        {
                            AppUserId = "1ee125f5-3be4-4bda-ae4c-d471762c414c",
                            VehicleId = "96d62347-64d8-425b-8a66-4b8cd78fc5a3"
                        },
                        new
                        {
                            AppUserId = "6c649c3c-a0f1-4065-832a-193cd3d9085d",
                            VehicleId = "1c4690e6-3e15-40f6-a6a2-7bdfe48817a2"
                        },
                        new
                        {
                            AppUserId = "21443f16-6bfb-4b07-8f35-d4a876266d5b",
                            VehicleId = "3e187f49-53b8-4049-b12d-3c80ab7a9048"
                        },
                        new
                        {
                            AppUserId = "d23d56ce-9953-4647-b594-340a50bf7320",
                            VehicleId = "e6ab22dc-f77a-4b94-8bef-ff8d2c9d16cb"
                        });
                });

            modelBuilder.Entity("AssetMon.Models.Payment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("VehicleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("AssetMon.Models.Vehicle", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContractType")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PaymentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PaymentFrequency")
                        .HasColumnType("int");

                    b.Property<string>("PlateNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Tenure")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = "96d62347-64d8-425b-8a66-4b8cd78fc5a3",
                            Color = "Blue",
                            ContractType = 1,
                            IsActive = false,
                            Name = "TVS",
                            PaymentAmount = 16000m,
                            PaymentFrequency = 1,
                            PlateNumber = "TVS-UMG-210-QR",
                            StartDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Tenure = 0
                        },
                        new
                        {
                            Id = "1c4690e6-3e15-40f6-a6a2-7bdfe48817a2",
                            Color = "Blue",
                            ContractType = 1,
                            IsActive = false,
                            Name = "Piaggio",
                            PaymentAmount = 16000m,
                            PaymentFrequency = 1,
                            StartDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Tenure = 0
                        },
                        new
                        {
                            Id = "3e187f49-53b8-4049-b12d-3c80ab7a9048",
                            Color = "Blue",
                            ContractType = 1,
                            IsActive = false,
                            Name = "TVS",
                            PaymentAmount = 16000m,
                            PaymentFrequency = 1,
                            PlateNumber = "TVS-M4L03958",
                            StartDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Tenure = 0
                        },
                        new
                        {
                            Id = "e6ab22dc-f77a-4b94-8bef-ff8d2c9d16cb",
                            Color = "Blue",
                            ContractType = 1,
                            IsActive = false,
                            Name = "TVS",
                            PaymentAmount = 16000m,
                            PaymentFrequency = 1,
                            PlateNumber = "TVS-M4L03941",
                            StartDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Tenure = 0
                        });
                });

            modelBuilder.Entity("AssetMon.Models.VehicleRepair", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("RepairName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("VehicleRepairs");

                    b.HasData(
                        new
                        {
                            Id = "f6040dcd-c639-4b07-94ce-0c7ef58d7250",
                            Amount = 3000m,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RepairName = "Shoe brakes",
                            VehicleId = "3e187f49-53b8-4049-b12d-3c80ab7a9048"
                        },
                        new
                        {
                            Id = "8c5ccdaa-eda0-4d29-94cc-aac10a0883f1",
                            Amount = 3000m,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RepairName = "Shoe brakes",
                            VehicleId = "1c4690e6-3e15-40f6-a6a2-7bdfe48817a2"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "80f06be8-2985-4ce8-95b6-48fef961fb79",
                            ConcurrencyStamp = "97e52c31-b73f-440a-9e3e-fb20eb3165c2",
                            Name = "Owner",
                            NormalizedName = "OWNER"
                        },
                        new
                        {
                            Id = "200048fd-e2bd-4d6f-a03d-bef839c3790e",
                            ConcurrencyStamp = "38df81cf-4ae8-4fdd-afb3-48ba220721b3",
                            Name = "Driver",
                            NormalizedName = "DRIVER"
                        },
                        new
                        {
                            Id = "9b8bb99e-c149-4e60-8f19-2e4f45303041",
                            ConcurrencyStamp = "72fee15d-bb99-40c9-b732-91e83478d757",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AssetMon.Models.Address", b =>
                {
                    b.HasOne("AssetMon.Models.AppUser", "AppUser")
                        .WithOne("Address")
                        .HasForeignKey("AssetMon.Models.Address", "AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("AssetMon.Models.Ownership", b =>
                {
                    b.HasOne("AssetMon.Models.AppUser", "AppUser")
                        .WithMany("Ownerships")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssetMon.Models.Vehicle", "Vehicle")
                        .WithMany("Ownerships")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("AssetMon.Models.Payment", b =>
                {
                    b.HasOne("AssetMon.Models.Vehicle", "Vehicle")
                        .WithMany("Payments")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("AssetMon.Models.VehicleRepair", b =>
                {
                    b.HasOne("AssetMon.Models.Vehicle", "Vehicle")
                        .WithMany("Repairs")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AssetMon.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AssetMon.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssetMon.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AssetMon.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AssetMon.Models.AppUser", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Ownerships");
                });

            modelBuilder.Entity("AssetMon.Models.Vehicle", b =>
                {
                    b.Navigation("Ownerships");

                    b.Navigation("Payments");

                    b.Navigation("Repairs");
                });
#pragma warning restore 612, 618
        }
    }
}
