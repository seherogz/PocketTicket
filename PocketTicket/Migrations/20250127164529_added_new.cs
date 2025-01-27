using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocketTicket.Migrations
{
    /// <inheritdoc />
    public partial class added_new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Passenger_Flights_FlightId",
                table: "Flight_Passenger");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Passenger_Passengers_PassengerId",
                table: "Flight_Passenger");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flight_Passenger",
                table: "Flight_Passenger");

            migrationBuilder.RenameTable(
                name: "Flight_Passenger",
                newName: "flight_Passengers");

            migrationBuilder.RenameIndex(
                name: "IX_Flight_Passenger_PassengerId",
                table: "flight_Passengers",
                newName: "IX_flight_Passengers_PassengerId");

            migrationBuilder.RenameIndex(
                name: "IX_Flight_Passenger_FlightId",
                table: "flight_Passengers",
                newName: "IX_flight_Passengers_FlightId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_flight_Passengers",
                table: "flight_Passengers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_flight_Passengers_Flights_FlightId",
                table: "flight_Passengers",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_flight_Passengers_Passengers_PassengerId",
                table: "flight_Passengers",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "PassengerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_flight_Passengers_Flights_FlightId",
                table: "flight_Passengers");

            migrationBuilder.DropForeignKey(
                name: "FK_flight_Passengers_Passengers_PassengerId",
                table: "flight_Passengers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_flight_Passengers",
                table: "flight_Passengers");

            migrationBuilder.RenameTable(
                name: "flight_Passengers",
                newName: "Flight_Passenger");

            migrationBuilder.RenameIndex(
                name: "IX_flight_Passengers_PassengerId",
                table: "Flight_Passenger",
                newName: "IX_Flight_Passenger_PassengerId");

            migrationBuilder.RenameIndex(
                name: "IX_flight_Passengers_FlightId",
                table: "Flight_Passenger",
                newName: "IX_Flight_Passenger_FlightId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flight_Passenger",
                table: "Flight_Passenger",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Passenger_Flights_FlightId",
                table: "Flight_Passenger",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Passenger_Passengers_PassengerId",
                table: "Flight_Passenger",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "PassengerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
