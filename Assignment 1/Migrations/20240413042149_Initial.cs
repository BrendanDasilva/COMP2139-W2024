using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "Identity",
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
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsernameChangeLimit = table.Column<int>(type: "int", nullable: false),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HotelLoyaltyID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrequentFlyerNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Cars",
                schema: "Identity",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    PricePerDay = table.Column<double>(type: "float", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                schema: "Identity",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Airline = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartureAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                schema: "Identity",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerNight = table.Column<double>(type: "float", nullable: false),
                    Amenities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ServiceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.HotelId);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarRentals",
                schema: "Identity",
                columns: table => new
                {
                    RentalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRentals", x => x.RentalId);
                    table.ForeignKey(
                        name: "FK_CarRentals_Cars_CarId",
                        column: x => x.CarId,
                        principalSchema: "Identity",
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightBookings",
                schema: "Identity",
                columns: table => new
                {
                    FlightBookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    Airline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightBookings", x => x.FlightBookingId);
                    table.ForeignKey(
                        name: "FK_FlightBookings_Flights_FlightId",
                        column: x => x.FlightId,
                        principalSchema: "Identity",
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelBookings",
                schema: "Identity",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelBookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_HotelBookings_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalSchema: "Identity",
                        principalTable: "Hotels",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Cars",
                columns: new[] { "CarId", "Brand", "IsAvailable", "Model", "PricePerDay", "Year" },
                values: new object[,]
                {
                    { 1, "Honda", true, "Civic Sport", 69.989999999999995, 2019 },
                    { 2, "Toyota", true, "Camry SE", 79.989999999999995, 2020 },
                    { 3, "Ford", true, "Mustang GT", 99.989999999999995, 2018 },
                    { 4, "Chevrolet", true, "Camaro SS", 109.98999999999999, 2021 },
                    { 5, "Nissan", true, "Altima SV", 74.989999999999995, 2020 },
                    { 6, "Hyundai", true, "Sonata Limited", 69.989999999999995, 2019 },
                    { 7, "Kia", true, "Optima EX", 64.989999999999995, 2018 },
                    { 8, "BMW", true, "3 Series", 129.99000000000001, 2020 },
                    { 9, "Mercedes-Benz", true, "C-Class", 139.99000000000001, 2021 },
                    { 10, "Audi", true, "A4 Premium", 119.98999999999999, 2019 }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Flights",
                columns: new[] { "FlightId", "Airline", "ArrivalAirport", "ArrivalTime", "DepartureAirport", "DepartureTime", "Destination", "Price" },
                values: new object[,]
                {
                    { 1, "Delta Airlines", "JFK", new DateTime(2024, 3, 15, 15, 45, 0, 0, DateTimeKind.Unspecified), "LAX", new DateTime(2024, 3, 15, 7, 30, 0, 0, DateTimeKind.Unspecified), "New York", 350.00m },
                    { 2, "American Airlines", "ORD", new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), "MIA", new DateTime(2024, 3, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", 280.00m },
                    { 3, "United Airlines", "SFO", new DateTime(2024, 4, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), "JFK", new DateTime(2024, 4, 5, 6, 45, 0, 0, DateTimeKind.Unspecified), "San Francisco", 400.00m },
                    { 4, "Southwest Airlines", "LAS", new DateTime(2024, 4, 10, 12, 50, 0, 0, DateTimeKind.Unspecified), "DEN", new DateTime(2024, 4, 10, 11, 15, 0, 0, DateTimeKind.Unspecified), "Las Vegas", 150.00m },
                    { 5, "JetBlue", "BOS", new DateTime(2024, 4, 15, 8, 30, 0, 0, DateTimeKind.Unspecified), "FLL", new DateTime(2024, 4, 15, 5, 0, 0, 0, DateTimeKind.Unspecified), "Boston", 200.00m },
                    { 6, "Alaska Airlines", "SEA", new DateTime(2024, 4, 20, 19, 0, 0, 0, DateTimeKind.Unspecified), "LAX", new DateTime(2024, 4, 20, 16, 0, 0, 0, DateTimeKind.Unspecified), "Seattle", 220.00m },
                    { 7, "Spirit Airlines", "DFW", new DateTime(2024, 5, 1, 16, 45, 0, 0, DateTimeKind.Unspecified), "ATL", new DateTime(2024, 5, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "Dallas", 95.00m },
                    { 8, "Frontier Airlines", "DEN", new DateTime(2024, 5, 10, 20, 35, 0, 0, DateTimeKind.Unspecified), "PHX", new DateTime(2024, 5, 10, 17, 20, 0, 0, DateTimeKind.Unspecified), "Denver", 115.00m },
                    { 9, "Hawaiian Airlines", "HNL", new DateTime(2024, 5, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), "LAX", new DateTime(2024, 5, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), "Honolulu", 500.00m },
                    { 10, "British Airways", "LHR", new DateTime(2024, 6, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), "JFK", new DateTime(2024, 6, 1, 22, 0, 0, 0, DateTimeKind.Unspecified), "London", 750.00m }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Hotels",
                columns: new[] { "HotelId", "Amenities", "BookingId", "IsAvailable", "Location", "Name", "PricePerNight", "ServiceType" },
                values: new object[,]
                {
                    { 1, "Yes", 0, false, "Manhattan, New York", "The Ritz Carlton", 1139.0, "Full Service" },
                    { 2, "Yes", 0, false, "Manhattan, New York", "The Plaza Hotel", 1780.0, "Full Service" },
                    { 4, "Yes", 0, false, "Paris, France", "Hotel Louvre Sainte Anne", 291.0, "Full Service" },
                    { 5, "Yes", 0, false, "Paris, France", "Hotel Brighton", 509.0, "Full Service" },
                    { 6, "Yes", 0, false, "Paris, France", "Solly Hotel Paris", 383.0, "Full Service" },
                    { 7, "Yes", 0, false, "Tokyo, Japan", "Grand Hyatt Tokyo", 987.0, "Full Service" },
                    { 8, "Yes", 0, false, "Tokyo, Japan", "The Prince Park Tower", 484.0, "Full Service" },
                    { 9, "Yes", 0, false, "Tokyo, Japan", "Four Seasons Hotel Tokyo", 1104.0, "Full Service" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "IdentityUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "bfb0b937-d9ff-457e-82fc-1dd640ff860e", "user@example.com", true, false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEMIFxOXKnF7n4sldhEtwWWWjp2B4Ca6OXiPTsB2IboxI7vXibxzCKg2/WBJ6qBEuMw==", null, false, "", false, "user@example.com" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "Identity",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "Identity",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "Identity",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "Identity",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentals_CarId",
                schema: "Identity",
                table: "CarRentals",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightBookings_FlightId",
                schema: "Identity",
                table: "FlightBookings",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelBookings_HotelId",
                schema: "Identity",
                table: "HotelBookings",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CarRentals",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "FlightBookings",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "HotelBookings",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "IdentityUser",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Cars",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Flights",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Hotels",
                schema: "Identity");
        }
    }
}
