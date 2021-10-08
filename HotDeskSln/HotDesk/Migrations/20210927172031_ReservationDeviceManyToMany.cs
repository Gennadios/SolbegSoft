using Microsoft.EntityFrameworkCore.Migrations;

namespace HotDesk.Migrations
{
    public partial class ReservationDeviceManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Reservations_ReservationId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_ReservationId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Devices");

            migrationBuilder.CreateTable(
                name: "DeviceReservation",
                columns: table => new
                {
                    DevicesId = table.Column<int>(type: "int", nullable: false),
                    ReservationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceReservation", x => new { x.DevicesId, x.ReservationsId });
                    table.ForeignKey(
                        name: "FK_DeviceReservation_Devices_DevicesId",
                        column: x => x.DevicesId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceReservation_Reservations_ReservationsId",
                        column: x => x.ReservationsId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceReservation_ReservationsId",
                table: "DeviceReservation",
                column: "ReservationsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceReservation");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Devices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_ReservationId",
                table: "Devices",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Reservations_ReservationId",
                table: "Devices",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
