using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salon_Frizerie_Canina.Migrations
{
    public partial class AppointmentDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dog_Customer_CustomerID",
                table: "Dog");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_Dog_DogId",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_DogId",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Dog_CustomerId",
                table: "Dog");

            migrationBuilder.DropColumn(
                name: "DogId",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Dog");

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.AddColumn<int>(
                name: "DogId",
                table: "Service",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Dog",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Service_DogId",
                table: "Service",
                column: "DogID");

            migrationBuilder.CreateIndex(
                name: "IX_Dog_CustomerId",
                table: "Dog",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dog_Customer_CustomerId",
                table: "Dog",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Dog_DogID",
                table: "Service",
                column: "DogId",
                principalTable: "Dog",
                principalColumn: "Id");
        }
    }
}
