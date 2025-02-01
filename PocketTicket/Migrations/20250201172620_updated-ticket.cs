using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocketTicket.Migrations
{
    /// <inheritdoc />
    public partial class updatedticket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "Tickets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "Reservations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PassengerId",
                table: "Passengers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FlightId",
                table: "Flights",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AirportId",
                table: "Airports",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tickets",
                newName: "TicketId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reservations",
                newName: "ReservationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Passengers",
                newName: "PassengerId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Flights",
                newName: "FlightId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Airports",
                newName: "AirportId");
        }
    }
}
