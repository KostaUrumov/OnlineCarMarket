﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineCarMarket_Infastructure.Data;

#nullable disable

namespace OnlineCarMarket_Infastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230818063621_ExpireDateAdded")]
    partial class ExpireDateAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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
                            Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            ConcurrencyStamp = "8bf2bec2-2bce-4093-8ae6-3f4b730ce5b0",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2c93174e-3b0e-446f-86af-883d56fr7210",
                            ConcurrencyStamp = "db32f78f-c700-491c-ba42-27dce02b51a7",
                            Name = "User",
                            NormalizedName = "USER"
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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("OnlineCarMarket_Infastructure.Entities.BodyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BoduTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sedan"
                        },
                        new
                        {
                            Id = 2,
                            Name = "SUV"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Kombi"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Limo"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Van"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Coupe"
                        },
                        new
                        {
                            Id = 7,
                            Name = "HatchBack"
                        });
                });

            modelBuilder.Entity("OnlineCarMarket_Infastructure.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BodyTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfRegistration")
                        .HasColumnType("datetime2");

                    b.Property<int>("EngineId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FirstRegistration")
                        .HasColumnType("datetime2");

                    b.Property<int>("ManifacturerId")
                        .HasColumnType("int");

                    b.Property<int>("Milage")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("NumberOfDoors")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(38, 18)
                        .HasColumnType("decimal(38,18)");

                    b.HasKey("Id");

                    b.HasIndex("BodyTypeId");

                    b.HasIndex("EngineId");

                    b.HasIndex("ManifacturerId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("OnlineCarMarket_Infastructure.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(56)
                        .HasColumnType("nvarchar(56)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Spain"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Japan"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Germany"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Sweden"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Italy"
                        },
                        new
                        {
                            Id = 6,
                            Name = "USA"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Romania"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Czech Republic"
                        },
                        new
                        {
                            Id = 9,
                            Name = "France"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Russia"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Great Britain"
                        });
                });

            modelBuilder.Entity("OnlineCarMarket_Infastructure.Entities.Engine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EngineTypeId")
                        .HasColumnType("int");

                    b.Property<double>("FuelConsumption")
                        .HasColumnType("float");

                    b.Property<int>("HorsePower")
                        .HasColumnType("int");

                    b.Property<int>("ManifacturerId")
                        .HasColumnType("int");

                    b.Property<int>("Volume")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EngineTypeId");

                    b.HasIndex("ManifacturerId");

                    b.ToTable("Engines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EngineTypeId = 1,
                            FuelConsumption = 10.800000000000001,
                            HorsePower = 150,
                            ManifacturerId = 1,
                            Volume = 2000
                        },
                        new
                        {
                            Id = 2,
                            EngineTypeId = 2,
                            FuelConsumption = 7.4000000000000004,
                            HorsePower = 140,
                            ManifacturerId = 8,
                            Volume = 1800
                        },
                        new
                        {
                            Id = 3,
                            EngineTypeId = 1,
                            FuelConsumption = 6.4000000000000004,
                            HorsePower = 90,
                            ManifacturerId = 13,
                            Volume = 1100
                        },
                        new
                        {
                            Id = 4,
                            EngineTypeId = 2,
                            FuelConsumption = 2.2000000000000002,
                            HorsePower = 80,
                            ManifacturerId = 4,
                            Volume = 900
                        },
                        new
                        {
                            Id = 5,
                            EngineTypeId = 3,
                            FuelConsumption = 1.0,
                            HorsePower = 90,
                            ManifacturerId = 7,
                            Volume = 500
                        },
                        new
                        {
                            Id = 6,
                            EngineTypeId = 2,
                            FuelConsumption = 5.2999999999999998,
                            HorsePower = 124,
                            ManifacturerId = 1,
                            Volume = 1600
                        },
                        new
                        {
                            Id = 7,
                            EngineTypeId = 4,
                            FuelConsumption = 14.5,
                            HorsePower = 184,
                            ManifacturerId = 3,
                            Volume = 2700
                        },
                        new
                        {
                            Id = 8,
                            EngineTypeId = 6,
                            FuelConsumption = 2.6000000000000001,
                            HorsePower = 186,
                            ManifacturerId = 4,
                            Volume = 600
                        },
                        new
                        {
                            Id = 9,
                            EngineTypeId = 1,
                            FuelConsumption = 6.7000000000000002,
                            HorsePower = 118,
                            ManifacturerId = 9,
                            Volume = 1500
                        });
                });

            modelBuilder.Entity("OnlineCarMarket_Infastructure.Entities.EngineType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Fuel")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("EngineTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Fuel = "Petrol"
                        },
                        new
                        {
                            Id = 2,
                            Fuel = "Diesel"
                        },
                        new
                        {
                            Id = 3,
                            Fuel = "Electricity"
                        },
                        new
                        {
                            Id = 4,
                            Fuel = "Petrol/LPG"
                        },
                        new
                        {
                            Id = 5,
                            Fuel = "Diesel/BioDiesel"
                        },
                        new
                        {
                            Id = 6,
                            Fuel = "Hybrid"
                        });
                });

            modelBuilder.Entity("OnlineCarMarket_Infastructure.Entities.Manifacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Manifacturers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 3,
                            Name = "BMW"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 3,
                            Name = "Mercedes"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 3,
                            Name = "Opel"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 2,
                            Name = "Honda"
                        },
                        new
                        {
                            Id = 5,
                            CountryId = 3,
                            Name = "Ford"
                        },
                        new
                        {
                            Id = 6,
                            CountryId = 5,
                            Name = "Fiat"
                        },
                        new
                        {
                            Id = 7,
                            CountryId = 8,
                            Name = "Skoda"
                        },
                        new
                        {
                            Id = 8,
                            CountryId = 6,
                            Name = "Chevrolet"
                        },
                        new
                        {
                            Id = 9,
                            CountryId = 10,
                            Name = "Lada"
                        },
                        new
                        {
                            Id = 10,
                            CountryId = 9,
                            Name = "Renault"
                        },
                        new
                        {
                            Id = 11,
                            CountryId = 9,
                            Name = "Peugeot"
                        },
                        new
                        {
                            Id = 12,
                            CountryId = 11,
                            Name = "Rover"
                        },
                        new
                        {
                            Id = 13,
                            CountryId = 1,
                            Name = "Seat"
                        });
                });

            modelBuilder.Entity("OnlineCarMarket_Infastructure.Entities.ObserveCars", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CarId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ObservingCars");
                });

            modelBuilder.Entity("OnlineCarMarket_Infastructure.Entities.User", b =>
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
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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
                });

            modelBuilder.Entity("OnlineCarMarket_Infastructure.Entities.UserCar", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CarId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersCars");
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
                    b.HasOne("OnlineCarMarket_Infastructure.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("OnlineCarMarket_Infastructure.Entities.User", null)
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

                    b.HasOne("OnlineCarMarket_Infastructure.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("OnlineCarMarket_Infastructure.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineCarMarket_Infastructure.Entities.Car", b =>
                {
                    b.HasOne("OnlineCarMarket_Infastructure.Entities.BodyType", "BodyType")
                        .WithMany()
                        .HasForeignKey("BodyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineCarMarket_Infastructure.Entities.Engine", "Engine")
                        .WithMany()
                        .HasForeignKey("EngineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineCarMarket_Infastructure.Entities.Manifacturer", "Manifacturer")
                        .WithMany()
                        .HasForeignKey("ManifacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BodyType");

                    b.Navigation("Engine");

                    b.Navigation("Manifacturer");
                });

            modelBuilder.Entity("OnlineCarMarket_Infastructure.Entities.Engine", b =>
                {
                    b.HasOne("OnlineCarMarket_Infastructure.Entities.EngineType", "Type")
                        .WithMany()
                        .HasForeignKey("EngineTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineCarMarket_Infastructure.Entities.Manifacturer", "Manifacturer")
                        .WithMany()
                        .HasForeignKey("ManifacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manifacturer");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("OnlineCarMarket_Infastructure.Entities.Manifacturer", b =>
                {
                    b.HasOne("OnlineCarMarket_Infastructure.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("OnlineCarMarket_Infastructure.Entities.ObserveCars", b =>
                {
                    b.HasOne("OnlineCarMarket_Infastructure.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineCarMarket_Infastructure.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineCarMarket_Infastructure.Entities.UserCar", b =>
                {
                    b.HasOne("OnlineCarMarket_Infastructure.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineCarMarket_Infastructure.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
