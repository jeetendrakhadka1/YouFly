using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace YouFly.web.Migrations
{
    public partial class SeedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AirportName = table.Column<string>(nullable: true),
                    Altitude = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    DST = table.Column<string>(nullable: true),
                    IATA = table.Column<string>(nullable: true),
                    ICAO = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Source = table.Column<string>(nullable: true),
                    TimeZone = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    UTC = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusSeatPrice = table.Column<int>(nullable: false),
                    CCExp = table.Column<int>(nullable: false),
                    CCNumber = table.Column<int>(nullable: false),
                    ConfimationNum = table.Column<int>(nullable: false),
                    FCSeatPrice = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    FlightIDFK = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    NumofBusSeats = table.Column<int>(nullable: false),
                    NumofFCSeats = table.Column<int>(nullable: false),
                    PhoneNum = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TicketDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    SeatType = table.Column<string>(nullable: true),
                    TransactionIDFK = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    FlightId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AirportEndId = table.Column<int>(nullable: true),
                    AirportStartId = table.Column<int>(nullable: true),
                    BusSeatPrice = table.Column<int>(nullable: false),
                    FCSeatPrice = table.Column<int>(nullable: false),
                    FlightDate = table.Column<DateTime>(nullable: false),
                    FlightTime = table.Column<DateTime>(nullable: false),
                    NumBusSeats = table.Column<int>(nullable: false),
                    NumFCSeats = table.Column<int>(nullable: false),
                    TravelDistance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flight_Airport_AirportEndId",
                        column: x => x.AirportEndId,
                        principalTable: "Airport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Airport_AirportStartId",
                        column: x => x.AirportStartId,
                        principalTable: "Airport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirportEndId",
                table: "Flight",
                column: "AirportEndId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirportStartId",
                table: "Flight",
                column: "AirportStartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "TicketDetails");

            migrationBuilder.DropTable(
                name: "Airport");
        }
    }
}
