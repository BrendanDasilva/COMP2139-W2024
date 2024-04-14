﻿// <auto-generated />
using System;
using Assignment1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240414162611_Update")]
    partial class Update
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Identity")
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assignment1.Models.ApplicationUser", b =>
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrequentFlyerNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelLoyaltyID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
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

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("UsernameChangeLimit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", "Identity");
                });

            modelBuilder.Entity("Assignment1.Models.CarRental", b =>
                {
                    b.Property<int>("RentalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentalId"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCanceled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PickupDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RentalId");

                    b.HasIndex("CarId");

                    b.ToTable("CarRentals", "Identity");
                });

            modelBuilder.Entity("Assignment1.Models.Cars", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarId"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PricePerDay")
                        .HasColumnType("float");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.ToTable("Cars", "Identity");

                    b.HasData(
                        new
                        {
                            CarId = 1,
                            Brand = "Honda",
                            IsAvailable = true,
                            Location = "Los Angeles",
                            Model = "Civic Sport",
                            PricePerDay = 69.989999999999995,
                            Year = 2019
                        },
                        new
                        {
                            CarId = 2,
                            Brand = "Toyota",
                            IsAvailable = true,
                            Location = "San Francisco",
                            Model = "Camry SE",
                            PricePerDay = 79.989999999999995,
                            Year = 2020
                        },
                        new
                        {
                            CarId = 3,
                            Brand = "Ford",
                            IsAvailable = true,
                            Location = "New York",
                            Model = "Mustang GT",
                            PricePerDay = 99.989999999999995,
                            Year = 2018
                        },
                        new
                        {
                            CarId = 4,
                            Brand = "Chevrolet",
                            IsAvailable = true,
                            Location = "Las Vegas",
                            Model = "Camaro SS",
                            PricePerDay = 109.98999999999999,
                            Year = 2021
                        },
                        new
                        {
                            CarId = 5,
                            Brand = "Nissan",
                            IsAvailable = true,
                            Location = "Miami",
                            Model = "Altima SV",
                            PricePerDay = 74.989999999999995,
                            Year = 2020
                        },
                        new
                        {
                            CarId = 6,
                            Brand = "Hyundai",
                            IsAvailable = true,
                            Location = "Seattle",
                            Model = "Sonata Limited",
                            PricePerDay = 69.989999999999995,
                            Year = 2019
                        },
                        new
                        {
                            CarId = 7,
                            Brand = "Kia",
                            IsAvailable = true,
                            Location = "Chicago",
                            Model = "Optima EX",
                            PricePerDay = 64.989999999999995,
                            Year = 2018
                        },
                        new
                        {
                            CarId = 8,
                            Brand = "BMW",
                            IsAvailable = true,
                            Location = "Boston",
                            Model = "3 Series",
                            PricePerDay = 129.99000000000001,
                            Year = 2020
                        },
                        new
                        {
                            CarId = 9,
                            Brand = "Mercedes-Benz",
                            IsAvailable = true,
                            Location = "San Diego",
                            Model = "C-Class",
                            PricePerDay = 139.99000000000001,
                            Year = 2021
                        },
                        new
                        {
                            CarId = 10,
                            Brand = "Audi",
                            IsAvailable = true,
                            Location = "Houston",
                            Model = "A4 Premium",
                            PricePerDay = 119.98999999999999,
                            Year = 2019
                        });
                });

            modelBuilder.Entity("Assignment1.Models.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightId"));

                    b.Property<string>("Airline")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ArrivalAirport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartureAirport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("FlightId");

                    b.ToTable("Flights", "Identity");

                    b.HasData(
                        new
                        {
                            FlightId = 1,
                            Airline = "Delta Airlines",
                            ArrivalAirport = "JFK",
                            ArrivalTime = new DateTime(2024, 3, 15, 15, 45, 0, 0, DateTimeKind.Unspecified),
                            DepartureAirport = "LAX",
                            DepartureTime = new DateTime(2024, 3, 15, 7, 30, 0, 0, DateTimeKind.Unspecified),
                            Destination = "New York",
                            Price = 350.00m
                        },
                        new
                        {
                            FlightId = 2,
                            Airline = "American Airlines",
                            ArrivalAirport = "ORD",
                            ArrivalTime = new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartureAirport = "MIA",
                            DepartureTime = new DateTime(2024, 3, 20, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Destination = "Chicago",
                            Price = 280.00m
                        },
                        new
                        {
                            FlightId = 3,
                            Airline = "United Airlines",
                            ArrivalAirport = "SFO",
                            ArrivalTime = new DateTime(2024, 4, 5, 10, 30, 0, 0, DateTimeKind.Unspecified),
                            DepartureAirport = "JFK",
                            DepartureTime = new DateTime(2024, 4, 5, 6, 45, 0, 0, DateTimeKind.Unspecified),
                            Destination = "San Francisco",
                            Price = 400.00m
                        },
                        new
                        {
                            FlightId = 4,
                            Airline = "Southwest Airlines",
                            ArrivalAirport = "LAS",
                            ArrivalTime = new DateTime(2024, 4, 10, 12, 50, 0, 0, DateTimeKind.Unspecified),
                            DepartureAirport = "DEN",
                            DepartureTime = new DateTime(2024, 4, 10, 11, 15, 0, 0, DateTimeKind.Unspecified),
                            Destination = "Las Vegas",
                            Price = 150.00m
                        },
                        new
                        {
                            FlightId = 5,
                            Airline = "JetBlue",
                            ArrivalAirport = "BOS",
                            ArrivalTime = new DateTime(2024, 4, 15, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            DepartureAirport = "FLL",
                            DepartureTime = new DateTime(2024, 4, 15, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            Destination = "Boston",
                            Price = 200.00m
                        },
                        new
                        {
                            FlightId = 6,
                            Airline = "Alaska Airlines",
                            ArrivalAirport = "SEA",
                            ArrivalTime = new DateTime(2024, 4, 20, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartureAirport = "LAX",
                            DepartureTime = new DateTime(2024, 4, 20, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            Destination = "Seattle",
                            Price = 220.00m
                        },
                        new
                        {
                            FlightId = 7,
                            Airline = "Spirit Airlines",
                            ArrivalAirport = "DFW",
                            ArrivalTime = new DateTime(2024, 5, 1, 16, 45, 0, 0, DateTimeKind.Unspecified),
                            DepartureAirport = "ATL",
                            DepartureTime = new DateTime(2024, 5, 1, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            Destination = "Dallas",
                            Price = 95.00m
                        },
                        new
                        {
                            FlightId = 8,
                            Airline = "Frontier Airlines",
                            ArrivalAirport = "DEN",
                            ArrivalTime = new DateTime(2024, 5, 10, 20, 35, 0, 0, DateTimeKind.Unspecified),
                            DepartureAirport = "PHX",
                            DepartureTime = new DateTime(2024, 5, 10, 17, 20, 0, 0, DateTimeKind.Unspecified),
                            Destination = "Denver",
                            Price = 115.00m
                        },
                        new
                        {
                            FlightId = 9,
                            Airline = "Hawaiian Airlines",
                            ArrivalAirport = "HNL",
                            ArrivalTime = new DateTime(2024, 5, 15, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartureAirport = "LAX",
                            DepartureTime = new DateTime(2024, 5, 15, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            Destination = "Honolulu",
                            Price = 500.00m
                        },
                        new
                        {
                            FlightId = 10,
                            Airline = "British Airways",
                            ArrivalAirport = "LHR",
                            ArrivalTime = new DateTime(2024, 6, 2, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartureAirport = "JFK",
                            DepartureTime = new DateTime(2024, 6, 1, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            Destination = "London",
                            Price = 750.00m
                        });
                });

            modelBuilder.Entity("Assignment1.Models.FlightBooking", b =>
                {
                    b.Property<int>("FlightBookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightBookingId"));

                    b.Property<string>("Airline")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArrivalAirport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartureAirport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("FlightBookingId");

                    b.HasIndex("FlightId");

                    b.ToTable("FlightBookings", "Identity");
                });

            modelBuilder.Entity("Assignment1.Models.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HotelId"));

                    b.Property<string>("Amenities")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PricePerNight")
                        .HasColumnType("float");

                    b.Property<string>("ServiceType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HotelId");

                    b.ToTable("Hotels", "Identity");

                    b.HasData(
                        new
                        {
                            HotelId = 1,
                            Amenities = "Yes",
                            BookingId = 0,
                            IsAvailable = false,
                            Location = "Manhattan, New York",
                            Name = "The Ritz Carlton",
                            PricePerNight = 1139.0,
                            ServiceType = "Full Service"
                        },
                        new
                        {
                            HotelId = 2,
                            Amenities = "Yes",
                            BookingId = 0,
                            IsAvailable = false,
                            Location = "Manhattan, New York",
                            Name = "The Plaza Hotel",
                            PricePerNight = 1780.0,
                            ServiceType = "Full Service"
                        },
                        new
                        {
                            HotelId = 4,
                            Amenities = "Yes",
                            BookingId = 0,
                            IsAvailable = false,
                            Location = "Paris, France",
                            Name = "Hotel Louvre Sainte Anne",
                            PricePerNight = 291.0,
                            ServiceType = "Full Service"
                        },
                        new
                        {
                            HotelId = 5,
                            Amenities = "Yes",
                            BookingId = 0,
                            IsAvailable = false,
                            Location = "Paris, France",
                            Name = "Hotel Brighton",
                            PricePerNight = 509.0,
                            ServiceType = "Full Service"
                        },
                        new
                        {
                            HotelId = 6,
                            Amenities = "Yes",
                            BookingId = 0,
                            IsAvailable = false,
                            Location = "Paris, France",
                            Name = "Solly Hotel Paris",
                            PricePerNight = 383.0,
                            ServiceType = "Full Service"
                        },
                        new
                        {
                            HotelId = 7,
                            Amenities = "Yes",
                            BookingId = 0,
                            IsAvailable = false,
                            Location = "Tokyo, Japan",
                            Name = "Grand Hyatt Tokyo",
                            PricePerNight = 987.0,
                            ServiceType = "Full Service"
                        },
                        new
                        {
                            HotelId = 8,
                            Amenities = "Yes",
                            BookingId = 0,
                            IsAvailable = false,
                            Location = "Tokyo, Japan",
                            Name = "The Prince Park Tower",
                            PricePerNight = 484.0,
                            ServiceType = "Full Service"
                        },
                        new
                        {
                            HotelId = 9,
                            Amenities = "Yes",
                            BookingId = 0,
                            IsAvailable = false,
                            Location = "Tokyo, Japan",
                            Name = "Four Seasons Hotel Tokyo",
                            PricePerNight = 1104.0,
                            ServiceType = "Full Service"
                        });
                });

            modelBuilder.Entity("Assignment1.Models.HotelBooking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelBookings", "Identity");
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

                    b.ToTable("AspNetRoles", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityUser", "Identity");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "aafed164-739b-405a-b046-5c5e3efb269d",
                            Email = "user@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@EXAMPLE.COM",
                            NormalizedUserName = "USER@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEElDqLFC13VdHy9riqHEu3S4ZR+ujKS0h8SULlK2+obnSc2upiBblgPfclvuuipong==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "user@example.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", "Identity");
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

                    b.ToTable("AspNetUserLogins", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", "Identity");
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

                    b.ToTable("AspNetUserTokens", "Identity");
                });

            modelBuilder.Entity("Assignment1.Models.CarRental", b =>
                {
                    b.HasOne("Assignment1.Models.Cars", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Assignment1.Models.FlightBooking", b =>
                {
                    b.HasOne("Assignment1.Models.Flight", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("Assignment1.Models.HotelBooking", b =>
                {
                    b.HasOne("Assignment1.Models.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
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
                    b.HasOne("Assignment1.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Assignment1.Models.ApplicationUser", null)
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

                    b.HasOne("Assignment1.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Assignment1.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
