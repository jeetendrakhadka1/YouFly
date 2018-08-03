using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace YouFly.web.Migrations
{
    public partial class TicketTx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusSeatPrice",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "FCSeatPrice",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "FlightIDFK",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "NumofBusSeats",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "NumofFCSeats",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "PhoneNum",
                table: "Transaction",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Transaction",
                newName: "TransactionId");

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlightId = table.Column<int>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    SeatClass = table.Column<string>(nullable: true),
                    TransactionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Ticket_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transaction",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_UserId",
                table: "Transaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_FlightId",
                table: "Ticket",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TransactionId",
                table: "Ticket",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_User_UserId",
                table: "Transaction",
                column: "UserId",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_User_UserId",
                table: "Transaction");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_UserId",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Transaction",
                newName: "PhoneNum");

            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "Transaction",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "BusSeatPrice",
                table: "Transaction",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FCSeatPrice",
                table: "Transaction",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Transaction",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FlightIDFK",
                table: "Transaction",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Transaction",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumofBusSeats",
                table: "Transaction",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumofFCSeats",
                table: "Transaction",
                nullable: false,
                defaultValue: 0);
        }
    }
}
