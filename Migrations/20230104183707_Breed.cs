using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salon_Frizerie_Canina.Migrations
{
    public partial class Breed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DogBreed");

            migrationBuilder.DropColumn(
                name: "Breed",
                table: "Dog");

            migrationBuilder.AddColumn<int>(
                name: "BreedId",
                table: "Appointment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_BreedId",
                table: "Appointment",
                column: "BreedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Breed_BreedId",
                table: "Appointment",
                column: "BreedId",
                principalTable: "Breed",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Breed_BreedId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_BreedId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "BreedId",
                table: "Appointment");

            migrationBuilder.AddColumn<string>(
                name: "Breed",
                table: "Dog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DogBreed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreedId = table.Column<int>(type: "int", nullable: false),
                    DogId = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogBreed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DogBreed_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DogBreed_Breed_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breed",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DogBreed_Dog_DogId",
                        column: x => x.DogId,
                        principalTable: "Dog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DogBreed_AppointmentId",
                table: "DogBreed",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DogBreed_BreedId",
                table: "DogBreed",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_DogBreed_DogId",
                table: "DogBreed",
                column: "DogId");
        }
    }
}
