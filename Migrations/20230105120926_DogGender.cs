using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salon_Frizerie_Canina.Migrations
{
    public partial class DogGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DogGender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogGender", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DogGender_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DogGender_Dog_DogId",
                        column: x => x.DogId,
                        principalTable: "Dog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DogGender_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DogGender_AppointmentId",
                table: "DogGender",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DogGender_DogId",
                table: "DogGender",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_DogGender_GenderId",
                table: "DogGender",
                column: "GenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DogGender");

            migrationBuilder.DropTable(
                name: "Gender");
        }
    }
}
