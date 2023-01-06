using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salon_Frizerie_Canina.Migrations
{
    public partial class AppointmentHour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AppointmentHour",
                table: "Appointment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentHour",
                table: "Appointment");
        }
    }
}