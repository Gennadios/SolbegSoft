﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotDesk.Migrations
{
    public partial class RemoveEndDateFromReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Reservations",
                newName: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Reservations",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
